using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletController {
    private List<Bullet> _bullets = new List<Bullet>();
    private BulletFactory _bulletFactory;
    private GameFactory _gameFactory;
    private ClampObjectInScreenService _clampService;
     
    public BulletController(BulletFactory bulletFactory, ClampObjectInScreenService clampService, GameFactory gameFactory) {
        _bulletFactory = bulletFactory;
        _clampService = clampService;
        _gameFactory = gameFactory;
    }

    public void GameUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _bullets.Add(Shoot(_gameFactory.Ship));
        }

        for (int i = 0; i < _bullets.Count; i++) {
            DecreaseBulletsTimer(_bullets[i]);
            TryDestroyBullet(_bullets[i]);
        }

        MoveBullets();
    }

    public void RemoveBullet(Bullet bullet) {
        _bulletFactory.ReturnObjectInPool(bullet);
        _bullets.Remove(bullet);
    }

    private Bullet Shoot(ShipMoveTest ship) {
        Bullet bullet = _bulletFactory.TakeObjectFromPool();
        bullet.Velosity = ship.GetShipVelocity() + ship.GetShipForward() * 100f;
        bullet.LifeTime = 2f;
        bullet.transform.position = ship.transform.position;
        return bullet;
    }

    private void DecreaseBulletsTimer(Bullet bullet) {
        bullet.LifeTime -= Time.deltaTime;
    }

    private void TryDestroyBullet(Bullet bullet) {
        if (bullet.LifeTime <= 0) {
            RemoveBullet(bullet);
        }
    }

    private void MoveBullets() {
        foreach (var item in _bullets) {
            item.transform.position += item.Velosity * Time.deltaTime;
            item.transform.position = _clampService.GetClampPosition(item.transform.position);
        }
    }
}
