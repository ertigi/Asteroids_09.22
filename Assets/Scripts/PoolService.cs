using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolService : IService {

    public void CleanUp<TObject>() where TObject : IPoolable {
        if (Implementation<TObject>.Pool != null) {
            Implementation<TObject>.Pool.CleanUp();
        }
    }

    public void Add<TObject>(TObject instance) where TObject : IPoolable {
        if (Implementation<TObject>.Pool == null) {
            Debug.Log(typeof(TObject).ToString());
            Implementation<TObject>.Pool = new ObjectPool<TObject>();
        }

        Implementation<TObject>.Pool.AddObject(instance);
    }

    public TObject Get<TObject>() where TObject : IPoolable =>
        Implementation<TObject>.Pool.GetObject();


    private static class Implementation<TObject> where TObject : IPoolable {
        public static ObjectPool<TObject> Pool;
    }
}
