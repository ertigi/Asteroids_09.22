using UnityEngine;

public class UFOFactory : IService {
    private AssetProvider _assetProvider;
    private PoolService _poolService;
    private ServicesContainer _servicesContainer;
    private Camera _camera;

    public UFOFactory(AssetProvider assetProvider, PoolService poolService, ServicesContainer servicesContainer, Camera camera) {
        _assetProvider = assetProvider;
        _poolService = poolService;
        _servicesContainer = servicesContainer;
        _camera = camera;
    }

    public UFO TakeObjectFromPool() {
        UFO uFO = _poolService.Get<UFO>();

        uFO.transform.position = _camera.ViewportToScreenPoint(new Vector3(1,1,1));

        return uFO;
    }

    public void ReturnObjectInPool(UFO uFO) =>
        _poolService.Add(uFO);

    public void CreateUFO() {
        UFO newUFO = _assetProvider.Instantiate<UFO>();
        newUFO.Init(_servicesContainer.Get<CollisionService>(), 30f);

        _poolService.Add(newUFO);
    }
}