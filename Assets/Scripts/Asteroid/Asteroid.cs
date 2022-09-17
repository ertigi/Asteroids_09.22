using UnityEngine;

public abstract class Asteroid : MonoBehaviour, IAsteroid {
    public abstract AsteroidType GetAsteroidType();

    public void Spawn() {
        gameObject.SetActive(true);
    }

    public void Despawn() {
        gameObject.SetActive(false);
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 0) {

        }
    }
}