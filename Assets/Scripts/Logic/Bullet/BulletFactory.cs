public class BulletFactory : IService{
    private Bullet _bulletPrefab;
    private ShipMoveTest _ship;
    private PoolService _poolService;
    private AssetProvider _assetProvider;

    public BulletFactory(AssetProvider assetProvider, PoolService poolService) {
        _poolService = poolService;
        _assetProvider = assetProvider;
    }

    public void CreateBullets() {
        for (int i = 0; i < 20; i++) {
            SpawnBullet();
        }
    }

    public Bullet TakeObjectFromPool() =>
        _poolService.Get<Bullet>();

    public void ReturnObjectInPool(Bullet bullet) =>
        _poolService.Add(bullet);

    private void SpawnBullet() =>
        _poolService.Add(_assetProvider.Instantiate<Bullet>());
}
