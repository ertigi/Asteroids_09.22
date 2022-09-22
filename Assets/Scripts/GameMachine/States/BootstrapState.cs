using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapState : IState {
    private GameStateMachine _gameStateMachine;
    private ServicesContainer _servicesContainer;
    private AssetContainer _assetContainer;
    private Camera _camera;

    public BootstrapState(GameStateMachine gameStateMachine, ServicesContainer servicesContainer, AssetContainer assetContainer, Camera camera) {
        _gameStateMachine = gameStateMachine;
        _servicesContainer = servicesContainer;
        _assetContainer = assetContainer;
        _camera = camera;
    }

    public void Enter() {
        RegisterServices();
        _gameStateMachine.Enter<LevelLoadState>();
    }
    public void Exit() {

    }

    private void RegisterServices() {
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
