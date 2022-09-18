using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable, ICollidableObject {
    public Vector3 Velosity;
    public float LifeTime;

    public void Spawn() {
        gameObject.SetActive(true);
    }

    public void Despawn() {
        gameObject.SetActive(false);
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }

    public int GetLayer() {
        return gameObject.layer;
    }
}
