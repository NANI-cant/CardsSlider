using System;

public class GameEndState : IEnterState {
    private GameStateMachine _gameStateMachine;
    private Game _game;
    private ScenesLoader _scenesLoader;
    private GameOverPanel _gameOverPanel;
    private GameplaySettings _settings;
    private PlayerProgress _progress;
    private ScoreCounter _score;
    private IInputService _input;

    public GameEndState(
        GameStateMachine gameStateMachine,
        Game game,
        ScenesLoader scenesLoader,
        GameOverPanel gameOverPanel,
        GameplaySettings settings,
        PlayerProgress playerProgress,
        ScoreCounter score,
        IInputService input
    ) {
        _gameStateMachine = gameStateMachine;
        _game = game;
        _scenesLoader = scenesLoader;
        _gameOverPanel = gameOverPanel;
        _settings = settings;
        _progress = playerProgress;
        _score = score;
        _input = input;
    }

    public void Enter() {
        _input.Disable();
        _progress.AddBank((int)(_score.Score * _settings.ConvertMultiplier));
        _game.GameOver?.Invoke();

        _gameOverPanel.GetComponent<Fade>().Show();
        _gameOverPanel.GetComponent<ScoreConverter>().StartConverting();
        _gameOverPanel.OkButton.onClick.AddListener(OnOkButtonClick);
    }

    private void OnOkButtonClick() {
        _scenesLoader.LoadMenu();
    }
}
