using System;

public class GameFactory : IService {
    public ShipMoveTest Ship { get; private set; }
    public AsteroidsController AsteroidsController { get; private set; }
    public BulletController BulletController { get; private set; }

    private AssetProvider _assetProvider;
    private BulletFactory _bulletFactory;
    private AsteroidFactory _asteroidFactory;
    private ClampObjectInScreenService _clampService;

    public GameFactory(AssetProvider assetProvider,
        BulletFactory bulletFactory,
        AsteroidFactory asteroidFactory,
        ClampObjectInScreenService clampObjectInScreenService) {
        _assetProvider = assetProvider;
        _bulletFactory = bulletFactory;
        _asteroidFactory = asteroidFactory;
        _clampService = clampObjectInScreenService;
    }

    public void CreateLevel() {
        CreatePlayer();
        CreateBulletController();
        CreateAsteroidController();
    }

    private void CreatePlayer() {
        Ship = _assetProvider.Instantiate<ShipMoveTest>();
    }

    private void CreateBulletController() {
        BulletController = new BulletController(_bulletFactory, _clampService, this);
    }

    private void CreateAsteroidController() {
        AsteroidsController = new AsteroidsController(_asteroidFactory, _clampService);
    }
}