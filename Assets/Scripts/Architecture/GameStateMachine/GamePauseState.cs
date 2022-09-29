using UnityEngine.UI;

public class GamePauseState : IState, IEnterState, IExitState {
    private GameStateMachine _gameStateMachine;
    private Game _game;
    private ScenesLoader _scenesLoader;
    private Button _continueButton;
    private Button _toMenuButton;
    private IInputService _input;

    public GamePauseState(GameStateMachine gameStateMachine, Game game, ScenesLoader scenesLoader, Button continueButton, Button toMenuButton, IInputService input) {
        _gameStateMachine = gameStateMachine;
        _game = game;
        _scenesLoader = scenesLoader;
        _continueButton = continueButton;
        _toMenuButton = toMenuButton;
        _input = input;
    }

    public void Enter() {
        _input.Disable();
        _continueButton.onClick.AddListener(_gameStateMachine.TranslateTo<GameRunningState>);
        _toMenuButton.onClick.AddListener(OnGameInterrupted);
        _game.GamePaused?.Invoke();
    }

    public void Exit() {
        _continueButton.onClick.RemoveListener(_gameStateMachine.TranslateTo<GameRunningState>);
        _toMenuButton.onClick.RemoveListener(OnGameInterrupted);
        _game.GameStarted?.Invoke();
    }

    private void OnGameInterrupted() {
        _scenesLoader.LoadMenu(true);
    }
}
