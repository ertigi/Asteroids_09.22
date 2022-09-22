using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : UpdateStateMachine {
    public GameStateMachine(ServicesContainer servicesContainer, AssetContainer assetContainer, GameSettings gameSettings, Camera camera) {
        _states = new Dictionary<Type, IState>() {
            [typeof(BootstrapState)] = new BootstrapState(this, servicesContainer, assetContainer, camera),
            [typeof(LevelLoadState)] = new LevelLoadState(this, servicesContainer.Get<GameFactory>()),
            [typeof(GameLoopState)] = new GameLoopState(this, servicesContainer.Get<GameFactory>()),
        };
    }
}
