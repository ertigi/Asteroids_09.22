using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : IService {
    private Dictionary<Type, UnityEngine.Object> _gameObjects;

    public AssetManager(AssetContainer assetContainer) {
        _gameObjects = new Dictionary<Type, UnityEngine.Object>() {
            [assetContainer.ShipMoveTest.GetType()] = assetContainer.ShipMoveTest,
            [assetContainer.SmallAsteroid.GetType()] = assetContainer.SmallAsteroid,
            [assetContainer.MediumAsteroid.GetType()] = assetContainer.MediumAsteroid,
            [assetContainer.BigAsteroid.GetType()] = assetContainer.BigAsteroid,
            [assetContainer.Bullet.GetType()] = assetContainer.Bullet,
        };
    }

    public Type Get<Type>() where Type : class =>
        _gameObjects[typeof(Type)] as Type;
}
