using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : IPoolable {
    private List<T> _objects;

    public ObjectPool() {
        _objects = new List<T>();
    }

    public void CleanUp() {
        _objects.ForEach(item => item.DestroyObject());
        _objects.Clear();
    }

    public void AddObject(T instance) {
        instance.Despawn();
        _objects.Add(instance);
    }

    public T GetObject() {
        T instance = _objects[0];
        _objects.RemoveAt(0);
        instance.Spawn();
        return instance;
    }
}

public interface IPoolable {
    void Spawn();
    void Despawn();
    void DestroyObject();
}