using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetProvider : IService {

    private AssetManager _assetManager;

    public AssetProvider(AssetManager assetManager) {
        _assetManager = assetManager;
    }

    public TObject Instantiate<TObject>() where TObject : MonoBehaviour =>
        Object.Instantiate(_assetManager.Get<TObject>());

    public TObject Instantiate<TObject>(Transform parent) where TObject : MonoBehaviour =>
        Object.Instantiate(_assetManager.Get<TObject>(), parent);

}
