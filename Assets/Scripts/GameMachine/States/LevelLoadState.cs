public class LevelLoadState : IState {
    private GameStateMachine _gameStateMachine;
    private GameFactory _gameFactory;

    public LevelLoadState(GameStateMachine gameStateMachine, GameFactory gameFactory) {
        _gameStateMachine = gameStateMachine;
        _gameFactory = gameFactory;
    }

    public void Enter() {
        CreateLevel();
        _gameStateMachine.Enter<GameLoopState>();
    }

    public void Exit() {

    }

    private void CreateLevel() {
        _gameFactory.CreateLevel();
    }
}
