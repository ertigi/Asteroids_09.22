public class BulletFactory {
    private Bullet _bulletPrefab;
    private ShipMoveTest _ship;
    private PoolService _poolService;

    public BulletFactory(Bullet bulletPrefab, PoolService poolService) {
        _bulletPrefab = bulletPrefab;
        _poolService = poolService;

        for (int i = 0; i < 20; i++) {
            SpawnBullet();
        }
    }

    public void SpawnBullet() => 
        _poolService.Add(UnityEngine.Object.Instantiate(_bulletPrefab));

    public Bullet TakeObjectFromPool() =>
        _poolService.Get<Bullet>();

    public void ReturnObjectInPool(Bullet bullet) =>
        _poolService.Add(bullet);
}
