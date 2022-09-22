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
        for (int i = 0; i < 8; i++) {
            _asteroids.Add(_asteroidFactory.GetBigAsteroid());
        }
    }

    public void GameUpdate() {
        if (_asteroids.Count == 0) {
            StartGame();
        } else {
            foreach (var item in _asteroids) {
                item.transform.position = _clampService.GetClampPosition(item.transform.position);
                item.transform.position += item.Velocity * Time.deltaTime;
            }
        }
    }

    public void DestroyAsteroid(Asteroid asteroid){
        // remove old asteroid
        _asteroidFactory.ReturnObjectInPool(asteroid);
        _asteroids.Remove(asteroid);
        // particle
        // ---
        // add points
        // ---
        // if (big or medium) -> spawn new asteroids
        if (asteroid.GetAsteroidType() == AsteroidType.Big || asteroid.GetAsteroidType() == AsteroidType.Medium) {
            SpawnNewAsteroids(asteroid);
        }
    }

    private void SpawnNewAsteroids(Asteroid asteroid) {
        for (int i = 0; i < 2; i++) {
            Asteroid newAsteroid = _asteroidFactory.GetLowerAsteroid(asteroid);
            _asteroids.Add(newAsteroid);
        }
    }
}