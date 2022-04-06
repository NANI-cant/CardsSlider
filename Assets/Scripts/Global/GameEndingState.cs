using System;

public class GameEndingState : IEnterState {
    private GameStateMachine _gameStateMachine;
    private Game _game;
    private ScenesLoader _scenesLoader;
    private GameOverPanel _gameOverPanel;

    public GameEndingState(GameStateMachine gameStateMachine, Game game, ScenesLoader scenesLoader, GameOverPanel gameOverPanel) {
        _gameStateMachine = gameStateMachine;
        _game = game;
        _scenesLoader = scenesLoader;
        _gameOverPanel = gameOverPanel;
    }

    public void Enter() {
        _game.OnGameOver?.Invoke();
        _gameOverPanel.OkButton.onClick.AddListener(OnOkButtonClick);
    }

    private void OnOkButtonClick() {
        _scenesLoader.LoadMenu();
    }
}
