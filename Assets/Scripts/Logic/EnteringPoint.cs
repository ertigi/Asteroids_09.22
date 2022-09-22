using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. init services
/// 2. level load
/// 3. game loop
/// </summary>

public class EnteringPoint : MonoBehaviour
{
    [SerializeField] private AssetContainer _assetContainer;
    [SerializeField] private Camera _camera;

    private ServicesContainer _servicesContainer;
    private GameFactory _gameFactory;

    private void Awake() {
        // bootstrap state
        ServicesInitialization();

        //level load state
        _servicesContainer.Get<AsteroidFactory>().CreateSteroids();
        _servicesContainer.Get<BulletFactory>().CreateBullets();
        _servicesContainer.Get<UFOFactory>().CreateUFO();

        _servicesContainer.Get<GameFactory>().CreateLevel();
    }
    private void Start() {
        // gameloop
        _gameFactory = _servicesContainer.Get<GameFactory>();

        _gameFactory.AsteroidsController.StartGame();
    }

    private void Update() {
        _gameFactory.BulletController.GameUpdate();
        _gameFactory.AsteroidsController.GameUpdate();
        _gameFactory.UFOController.GameUpdate();
    }

    private void ServicesInitialization() {
        _servicesContainer = new ServicesContainer();

        _servicesContainer.Set(new AssetManager(_assetContainer));
        _servicesContainer.Set(new AssetProvider(_servicesContainer.Get<AssetManager>()));


        _servicesContainer.Set(new PoolService());
        _servicesContainer.Set(new ClampObjectInScreenService(_camera));


        _servicesContainer.Set(new BulletFactory(_servicesContainer.Get<AssetProvider>(),
            _servicesContainer.Get<PoolService>()));
        _servicesContainer.Set(new AsteroidFactory(_servicesContainer.Get<AssetProvider>(),
            _servicesContainer.Get<PoolService>(),
            _servicesContainer,
            _camera));
        _servicesContainer.Set(new UFOFactory(_servicesContainer.Get<AssetProvider>(),
            _servicesContainer.Get<PoolService>(),
            _servicesContainer,
            _camera));


        _servicesContainer.Set(new GameFactory(_servicesContainer.Get<AssetProvider>(),
            _servicesContainer.Get<BulletFactory>(),
            _servicesContainer.Get<AsteroidFactory>(),
            _servicesContainer.Get<ClampObjectInScreenService>(),
            _servicesContainer.Get<UFOFactory>()));


        _servicesContainer.Set(new CollisionService(_servicesContainer.Get<GameFactory>()));
    }
}


