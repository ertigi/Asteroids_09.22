using System;

public class GameFactory : IService {
    public ShipMoveTest Ship { get; private set; }
    public AsteroidsController AsteroidsController { get; private set; }
    public BulletController BulletController { get; private set; }
    public UFOController UFOController { get; private set; }


    private AssetProvider _assetProvider;


    private BulletFactory _bulletFactory;
    private AsteroidFactory _asteroidFactory;
    private ClampObjectInScreenService _clampService;
    private UFOFactory _uFOFactory;

    public GameFactory(AssetProvider assetProvider,
        BulletFactory bulletFactory,
        AsteroidFactory asteroidFactory,
        ClampObjectInScreenService clampObjectInScreenService,
        UFOFactory uFOFactory) {
        _assetProvider = assetProvider;
        _bulletFactory = bulletFactory;
        _asteroidFactory = asteroidFactory;
        _clampService = clampObjectInScreenService;
        _uFOFactory = uFOFactory;
    }

    public void CreateLevel() {
        _asteroidFactory.CreateSteroids();
        _bulletFactory.CreateBullets();
        _uFOFactory.CreateUFO();

        CreatePlayer();
        CreateBulletController();
        CreateAsteroidController();
        CreateUFOController();
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
    
    private void CreateUFOController() {
        UFOController = new UFOController(_uFOFactory, this, _clampService);
    }
}