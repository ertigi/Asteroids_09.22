using System.Collections;
using UnityEngine;

public class AsteroidCollisionService : IService {
    private BulletController _bulletController;

    public AsteroidCollisionService(BulletController bulletController) {
        _bulletController = bulletController;
    }


}

