using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampObjectInScreenService : IService
{
    private Camera _camera;
    private Vector2 _minScreanPoint, _maxScreanPoint;

    public ClampObjectInScreenService(Camera camera) {
        _camera = camera;
        _minScreanPoint = camera.ViewportToWorldPoint(Vector2.zero);
        _maxScreanPoint = camera.ViewportToWorldPoint(Vector2.one);
    }

    public Vector3 GetClampPosition(Vector3 objectPositionInWorld) =>
        new Vector3(ClampX(objectPositionInWorld.x), ClampY(objectPositionInWorld.y), 0);
    
    private float ClampX(float x) {
        if (x <= _minScreanPoint.x)
            x = _maxScreanPoint.x;
        else if (x >= _maxScreanPoint.x)
            x = _minScreanPoint.x;

        return x;
    }
    private float ClampY(float y) {
        if (y <= _minScreanPoint.y)
            y = _maxScreanPoint.y;
        else if (y >= _maxScreanPoint.y)
            y = _minScreanPoint.y;

        return y;
    }
}
