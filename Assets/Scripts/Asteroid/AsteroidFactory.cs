using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : IService {
    private PoolService _poolService;
    private ServicesContainer _servicesContainer;
    private AssetProvider _assetProvider;

    public AsteroidFactory(AssetProvider assetProvider, PoolService poolService, ServicesContainer servicesContainer) {
        _assetProvider = assetProvider;
        _poolService = poolService;
        _servicesContainer = servicesContainer;
    }

    public void CreateSteroids() {
        AddAsteroidsInPool<BigAsteroid>(10);
        AddAsteroidsInPool<MediumAsteroid>(20);
        AddAsteroidsInPool<SmallAsteroid>(40);
    }

    public Asteroid GetAsteroid(AsteroidType type){
        if (type == AsteroidType.Small) {
            return InitAsteroid<SmallAsteroid>();
        } else if (type == AsteroidType.Medium) {
            return InitAsteroid<MediumAsteroid>();
        } else {
            return InitAsteroid<BigAsteroid>();
        }
    }

    public void ReturnObjectInPool(Asteroid asteroid) {
        if (asteroid.GetAsteroidType() == AsteroidType.Small) {
            _poolService.Add(asteroid as SmallAsteroid);
        } else if (asteroid.GetAsteroidType() == AsteroidType.Medium) {
            _poolService.Add(asteroid as MediumAsteroid);
        } else {
            _poolService.Add(asteroid as BigAsteroid);
        }
    }

    private TAsteroid InitAsteroid<TAsteroid>() where TAsteroid : Asteroid {
        Vector2 moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        float asteroidSpeed = Random.Range(40, 70);

        TAsteroid newAsteroid = _poolService.Get<TAsteroid>();
        newAsteroid.SetMovementParameters(moveDirection * asteroidSpeed);

        return newAsteroid;
    }


    private void AddAsteroidsInPool<T>(int count) where T : Asteroid{
        for (int i = 0; i < count; i++) {
            T asteroid = _assetProvider.Instantiate<T>();
            asteroid.Init(_servicesContainer.Get<CollisionService>());
            _poolService.Add(asteroid);
        }
    }
}