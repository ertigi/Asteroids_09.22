using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionService : IService {
    private GameFactory _gameFactory;

    public CollisionService(GameFactory gameFactory) {
        _gameFactory = gameFactory;
    }

    public void Collision(ICollidableObject collidedObject1, ICollidableObject collidedObject2){
        Debug.Log("Collision");
        if (collidedObject1.GetLayer() == 8)
            AsteroidCollision(collidedObject1 as Asteroid, collidedObject2);
    }

    private void AsteroidCollision(Asteroid asteroid, ICollidableObject collidedObject) {
        _gameFactory.AsteroidsController.DestroyAsteroid(asteroid);

        if (collidedObject.GetLayer() == 7)
            BulletCollision(collidedObject as Bullet);
        else if (collidedObject.GetLayer() == 6)
            PlayerCollision(collidedObject as ShipMoveTest);
    }

    private void BulletCollision(Bullet bullet) {
        _gameFactory.BulletController.RemoveBullet(bullet);
    }

    private void PlayerCollision(ShipMoveTest shipMoveTest) {

    }
}

public interface ICollidableObject {
    int GetLayer();
}
