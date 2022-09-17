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
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private List<Asteroid> _asteroids = new List<Asteroid>();

    private BulletController _bulletController;
    private ServicesContainer _servicesContainer;

    private void Awake() {
        ServicesInitialization();
    }

    private void Start() {
        ShipMoveTest shipMoveTest = FindObjectOfType<ShipMoveTest>();

        _bulletController = new BulletController(new BulletFactory(_bulletPrefab, _servicesContainer.Get<PoolService>()), shipMoveTest);

        new AsteroidFactory(_asteroids, _servicesContainer.Get<PoolService>());
    }

    private void Update() {
        _bulletController.GameUpdate();
    }

    private void ServicesInitialization() {
        _servicesContainer = new ServicesContainer();

        _servicesContainer.Set(new PoolService());
    }
}


