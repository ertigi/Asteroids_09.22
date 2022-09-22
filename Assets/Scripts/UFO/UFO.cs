using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour, IPoolable, ICollidableObject{
    public float Speed { get; private set; }

    private CollisionService _collisionService;

    public void Init(CollisionService collisionService, float speed) {
        _collisionService = collisionService;
        Speed = speed;
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
