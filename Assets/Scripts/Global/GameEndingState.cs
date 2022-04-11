using System;

public class GameEndingState : IEnterState {
    private GameStateMachine _gameStateMachine;
    private Game _game;
    private ScenesLoader _scenesLoader;
    private GameOverPanel _gameOverPanel;
    private GameplaySettings _settings;
    private PlayerProgress _progress;
    private ScoreCounter _score;

    public GameEndingState(
        GameStateMachine gameStateMachine,
        Game game,
        ScenesLoader scenesLoader,
        GameOverPanel gameOverPanel,
        GameplaySettings settings,
        PlayerProgress playerProgress,
        ScoreCounter score
    ) {
        _gameStateMachine = gameStateMachine;
        _game = game;
        _scenesLoader = scenesLoader;
        _gameOverPanel = gameOverPanel;
        _settings = settings;
        _progress = playerProgress;
        _score = score;
    }

    public void Enter() {
        _progress.AddBank((int)(_score.Score * _settings.ConvertMultiplier));
        _game.OnGameOver?.Invoke();
        _gameOverPanel.OkButton.onClick.AddListener(OnOkButtonClick);
    }

    private void OnOkButtonClick() {
        _scenesLoader.LoadMenu();
    }
}
