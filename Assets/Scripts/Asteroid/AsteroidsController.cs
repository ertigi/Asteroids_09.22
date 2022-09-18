using System.Collections.Generic;
using UnityEngine;

public class AsteroidsController {
    private AsteroidFactory _asteroidFactory;
    private ClampObjectInScreenService _clampService;
    private List<Asteroid> _asteroids;

    public AsteroidsController(AsteroidFactory asteroidFactory, ClampObjectInScreenService clampService) {
        _asteroidFactory = asteroidFactory;
        _clampService = clampService;
        _asteroids = new List<Asteroid>();
    }

    public void StartGame() {
        SpawnAsteroids(AsteroidType.Big, 8);
    }

    public void GameUpdate() {
        foreach (var item in _asteroids) {
            item.transform.position += item.Velocity * Time.deltaTime;
            item.transform.position = _clampService.GetClampPosition(item.transform.position);
        }
    }

    public void DestroyAsteroid(Asteroid asteroid){
        // remove old asteroid
        _asteroidFactory.ReturnObjectInPool(asteroid);
        // particle
        // ---
        // add points
        // ---
        // if (big or medium) -> spawn new asteroids
        if(asteroid.GetAsteroidType() == AsteroidType.Big) {
            SpawnAsteroids(AsteroidType.Medium, 2);
        } else if (asteroid.GetAsteroidType() == AsteroidType.Medium) {
            SpawnAsteroids(AsteroidType.Small, 2);
        }
    }

    private void SpawnAsteroids(AsteroidType type, int count) {
        for (int i = 0; i < count; i++) {
            _asteroids.Add(_asteroidFactory.GetAsteroid(type));
        }
    }
}