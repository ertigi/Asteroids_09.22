using System.Collections.Generic;
using UnityEngine;

public class AsteroidFactory : IService {
    private PoolService _poolService;
    private ServicesContainer _servicesContainer;
    private Camera _camera;
    private AssetProvider _assetProvider;

    public AsteroidFactory(AssetProvider assetProvider, PoolService poolService, ServicesContainer servicesContainer, Camera camera) {
        _assetProvider = assetProvider;
        _poolService = poolService;
        _servicesContainer = servicesContainer;
        _camera = camera;
    }

    public void CreateSteroids() {
        AddAsteroidsInPool<BigAsteroid>(10);
        AddAsteroidsInPool<MediumAsteroid>(20);
        AddAsteroidsInPool<SmallAsteroid>(40);
    }

    public Asteroid GetBigAsteroid() {
        return InitBigAsteroid();
    }

    public Asteroid GetLowerAsteroid(Asteroid asteroid) {
        if (asteroid.GetAsteroidType() == AsteroidType.Medium) {
            return InitLowerAsteroid<SmallAsteroid>(asteroid);
        } else {
            return InitLowerAsteroid<MediumAsteroid>(asteroid);
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

    private BigAsteroid InitBigAsteroid() {
        BigAsteroid newAsteroid = _poolService.Get<BigAsteroid>();
        newAsteroid.SetMovementParameters(CalculateRandomNormalizedDirection() * CalculateStartSpeed());
        newAsteroid.transform.position = _camera.ViewportToWorldPoint(CalculateRandomPositionOnView());
        return newAsteroid;
    }

    private TAsteroid InitLowerAsteroid<TAsteroid>(Asteroid parentAsteroid) where TAsteroid : Asteroid {
        TAsteroid newAsteroid = _poolService.Get<TAsteroid>();
        newAsteroid.transform.position = parentAsteroid.transform.position;

        Vector2 moveDirection = (CalculateRandomNormalizedDirection() + parentAsteroid.Velocity.normalized).normalized;
        float asteroidSpeed = CalculateStartSpeed();
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

    private Vector2 CalculateRandomPositionOnView() =>
        new Vector2(CalculateCoordinate(), CalculateCoordinate());

    private float CalculateCoordinate() {
        float c = 0;
        do {
            c = Random.Range(0f, 1f);
        } while (c < .7f && c > .3f);
        return c;
    }

    private Vector3 CalculateRandomNormalizedDirection() =>
        new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

    private float CalculateStartSpeed() =>
        Random.Range(40f, 70f);
}