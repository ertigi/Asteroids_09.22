using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreloader : MonoBehaviour
{
    [SerializeField] private AssetContainer _assetContainer;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private Camera _camera;

    private GameService _gameSystem;

    private void Awake() {
        Application.targetFrameRate = 300;

        DontDestroyOnLoad(gameObject);

        _gameSystem = new GameService(_assetContainer, _gameSettings, _camera);
    }

    private void Update() {
        _gameSystem.GameUpdate();
    }

    private void FixedUpdate() {
        _gameSystem.GameFixedUpdate();
    }

    private void LateUpdate() {
        _gameSystem.GameLateUpdate();
    }
}

public class GameService {
    private GameStateMachine _gameStateMachine;
    private ServicesContainer _servicesContainer;

    public GameService(AssetContainer assetContainer, GameSettings gameSettings, Camera camera) {
        _servicesContainer = new ServicesContainer();

        _gameStateMachine = new GameStateMachine(_servicesContainer, assetContainer, gameSettings, camera);
    }

    public void GameUpdate() {
        _gameStateMachine.UpdateState();
    }

    public void GameFixedUpdate() {
        _gameStateMachine.FixedUpdateState();
    }

    public void GameLateUpdate() {
        _gameStateMachine.LateUpdateState();
    }
}
