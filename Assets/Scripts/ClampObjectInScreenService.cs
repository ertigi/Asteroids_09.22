using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampObjectInScreenService : IService
{
    private Camera _camera;

    public ClampObjectInScreenService(Camera camera) {
        _camera = camera;
    }

    public Vector3 GetClampPosition(Vector3 objectPositionInWorld) {
        Vector2 view = Camera.main.WorldToViewportPoint(objectPositionInWorld);

        objectPositionInWorld = new Vector3(objectPositionInWorld.x * ((view.x < 0 || view.x > 1) ? -1 : 1),
            objectPositionInWorld.y * ((view.y < 0 || view.y > 1) ? -1 : 1),
            0);

        return objectPositionInWorld;
    }
}
