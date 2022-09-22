using System;
using UnityEngine;

public abstract class Asteroid : MonoBehaviour, IPoolable, ICollidableObject {
    public abstract AsteroidType GetAsteroidType();
    public Vector3 Velocity { get; private set; }

    private CollisionService _collisionService;

    public void Init(CollisionService collisionServices) {
        _collisionService = collisionServices;
    }

    public void SetMovementParameters(Vector2 velocity) {
        Velocity = velocity;
    }

    public void Spawn() => 
        gameObject.SetActive(true);

    public void Despawn() => 
        gameObject.SetActive(false);

    public void DestroyObject() => 
        Destroy(gameObject);

    public int GetLayer() =>
        gameObject.layer;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent(out ICollidableObject collidableObject))
            _collisionService.Collision(this, collidableObject);
    }
}
