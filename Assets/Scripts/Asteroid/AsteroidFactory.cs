using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AsteroidFactory {
    private PoolService _poolService;

    public AsteroidFactory(List<Asteroid> asteroids, PoolService poolService) {
        _poolService = poolService;

        FillPools(asteroids);

        ReturnObjectInPool(TakeObjectFromPool<BigAsteroid>());
    }

    public T TakeObjectFromPool<T>() where T : Asteroid =>
        _poolService.Get<T>();

    public void ReturnObjectInPool<T>(T asteroid) where T : Asteroid =>
        _poolService.Add(asteroid);

    private void FillPools(List<Asteroid> asteroids) {
        foreach (var item in asteroids) {
            if (item.GetAsteroidType() == AsteroidType.Small) {
                CreateAsteroids(item as SmallAsteroid, 10);
            } else if (item.GetAsteroidType() == AsteroidType.Medium) {
                CreateAsteroids(item as MediumAsteroid, 10);
            } else {
                CreateAsteroids(item as BigAsteroid, 10);
            }
        }
    }

    private void CreateAsteroids<T>(T asteroid, int count) where T : Asteroid{
        for (int i = 0; i < count; i++) {
            _poolService.Add(Object.Instantiate(asteroid));
        }
    }
}