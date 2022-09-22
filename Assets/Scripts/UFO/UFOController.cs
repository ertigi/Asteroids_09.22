using System.Collections.Generic;
using UnityEngine;

public class UFOController {
    private List<UFO> _uFOs;
    private UFOFactory _uFOFactory;
    private ClampObjectInScreenService _clampService;
    private Transform _target;
    private float _timer = 5f;
    private bool _isUFOSpawned;

    public UFOController (UFOFactory uFOFactory, GameFactory gameFactory, ClampObjectInScreenService clampService) {
        _uFOFactory = uFOFactory;
        _clampService = clampService;
        _target = gameFactory.Ship.transform;

        _uFOs = new List<UFO>();
    }

    public void GameUpdate() {
        if (_isUFOSpawned) {
            MoveUFO();
        }
        else {
            _timer -= Time.deltaTime;
            if (_timer < 0)
                SpawnUFO();
        }
    }

    public void DestroyUFO(UFO uFO) {
        _isUFOSpawned = false;
        _timer = 5f;
        _uFOs.Remove(uFO);
        _uFOFactory.ReturnObjectInPool(uFO);
    }

    private void MoveUFO() {
        for (int i = 0; i < _uFOs.Count; i++) {
            _uFOs[i].transform.position = CalculateNewUFOPosition(_uFOs[i].transform.position, _uFOs[i].Speed);
        }
    }

    private Vector3 CalculateNewUFOPosition(Vector3 currentPosition, float speed) {
        Vector3 position = _clampService.GetClampPosition(currentPosition);
        Vector3 direction = (_target.position - position).normalized;
        position += direction * (speed * Time.deltaTime);
        return position;
    }

    private void SpawnUFO() {
        _isUFOSpawned = true;
        _uFOs.Add(_uFOFactory.TakeObjectFromPool());
    }
}
