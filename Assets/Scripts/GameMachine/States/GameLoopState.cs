public class GameLoopState : IState, IUpdateState {
    private GameStateMachine _gameStateMachine;
    private GameFactory _gameFactory;

    public GameLoopState(GameStateMachine gameStateMachine, GameFactory gameFactory) {
        _gameStateMachine = gameStateMachine;
        _gameFactory = gameFactory;
    }

    public void Enter() {

    }

    public void Exit() {

    }

    public void GameUpdate() {
        _gameFactory.BulletController.GameUpdate();
        _gameFactory.AsteroidsController.GameUpdate();
        _gameFactory.UFOController.GameUpdate();
    }
}
