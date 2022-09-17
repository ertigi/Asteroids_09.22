using System.Collections.Generic;
using UnityEngine;

public class BulletController {
    private List<Bullet> _bullets = new List<Bullet>();
    private BulletFactory _bulletFactory;
    private ShipMoveTest _shipMoveTest;

    public BulletController(BulletFactory bulletFactory, ShipMoveTest shipMoveTest) {
        _bulletFactory = bulletFactory;
        _shipMoveTest = shipMoveTest;
    }

    public void GameUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _bullets.Add(Shoot());
        }

        for (int i = 0; i < _bullets.Count; i++) {
            _bullets[i].LifeTime -= Time.deltaTime;
            if (_bullets[i].LifeTime <= 0) {
                _bulletFactory.ReturnObjectInPool(_bullets[i]);
                _bullets.RemoveAt(i);
            }
        }

        for (int i = 0; i < _bullets.Count; i++) {
            _bullets[i].transform.position += _bullets[i].Velosity * Time.deltaTime;

            Vector2 position = Camera.main.WorldToViewportPoint(_bullets[i].transform.position);

            _bullets[i].transform.position = new Vector3(_bullets[i].transform.position.x * ((position.x < 0 || position.x > 1) ? -1 : 1),
                0,
                _bullets[i].transform.position.z * ((position.y < 0 || position.y > 1) ? -1 : 1));
        }
    }

    private Bullet Shoot() {
        Bullet bullet = _bulletFactory.TakeObjectFromPool();
        bullet.Velosity = _shipMoveTest.GetShipVelocity() + _shipMoveTest.GetShipForward() * 100f;
        bullet.LifeTime = 2f;
        bullet.transform.position = _shipMoveTest.transform.position;
        return bullet;
    }
}
