using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionService : IService {
    private GameFactory _gameFactory;

    public CollisionService(GameFactory gameFactory) {
        _gameFactory = gameFactory;
    }

    public void Collision(ICollidableObject collidedObject1, ICollidableObject collidedObject2){
        if (collidedObject1.GetLayer() == 8)
            AsteroidCollision(collidedObject1 as Asteroid, collidedObject2);
        else if (collidedObject1.GetLayer() == 9)
            UFOCollision(collidedObject1 as UFO, collidedObject2);
    }

    private void AsteroidCollision(Asteroid asteroid, ICollidableObject collidedObject) {
        _gameFactory.AsteroidsController.DestroyAsteroid(asteroid);

        if (collidedObject.GetLayer() == 7)
            BulletCollision(collidedObject as Bullet);
        else if (collidedObject.GetLayer() == 6)
            PlayerCollision(collidedObject as ShipMoveTest);
    }
    
    private void UFOCollision(UFO ufo, ICollidableObject collidedObject) {
        _gameFactory.UFOController.DestroyUFO(ufo);

        if (collidedObject.GetLayer() == 7)
            BulletCollision(collidedObject as Bullet);
        else if (collidedObject.GetLayer() == 6)
            PlayerCollision(collidedObject as ShipMoveTest);
    }


    private void BulletCollision(Bullet bullet) {
        _gameFactory.BulletController.RemoveBullet(bullet);
    }

    private void PlayerCollision(ShipMoveTest shipMoveTest) {
        Debug.Log("lose");
    }
}

public interface ICollidableObject {
    int GetLayer();
}
