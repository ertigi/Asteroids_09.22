using System;
using System.Collections;
using UnityEngine;

public class ShipMoveTest : MonoBehaviour, ICollidableObject {
    [SerializeField] private float _speed = 50f,
        _rotateSpeed = 5f,
        _brakeSpeed = .25f;

    private Vector3 _currentVelosity;

    public Vector3 GetShipForward() => transform.up;

    public Vector3 GetShipVelocity() => _currentVelosity;

    private void Update() {
        Rotate();
        CalculateAcceleration();
        ShipMove();
        ClampShipInScrean();
    }

    private void Rotate() {
        if (Input.GetKey(KeyCode.A)) { // left
            transform.Rotate(Vector3.forward, _rotateSpeed);
        } else if (Input.GetKey(KeyCode.D)) { // right
            transform.Rotate(Vector3.forward, -_rotateSpeed);
        }
    }

    private void CalculateAcceleration() {
        if (Input.GetKey(KeyCode.W)) {
            _currentVelosity += transform.up * (_speed * Time.deltaTime);
        } else {
            _currentVelosity = Vector3.Lerp(_currentVelosity, Vector3.zero, Time.deltaTime * _brakeSpeed);
        }

    }

    private void ShipMove() {
        transform.position += _currentVelosity * Time.deltaTime;
    }

    private void ClampShipInScrean() {
        Vector2 position = Camera.main.WorldToViewportPoint(transform.position);

        transform.position = new Vector3(transform.position.x * ((position.x < 0 || position.x > 1) ? -1 : 1),
            transform.position.y * ((position.y < 0 || position.y > 1) ? -1 : 1),
            0);
    }

    public int GetLayer() =>
        gameObject.layer;
}
