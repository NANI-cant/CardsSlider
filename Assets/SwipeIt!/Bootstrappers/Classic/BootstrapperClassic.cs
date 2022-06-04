using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BootstrapperClassic : MonoInstaller {
    [Header("Static Data")]
    [SerializeField] private ClassicGameplaySettings _settings;

    [Header("Gameplay")]
    [SerializeField] private AnswerHandler _answerHandler;
    [SerializeField] private CardDragger _cardDragger;
    [SerializeField] private FigureGenerator _figureGenerator;
    [SerializeField] private CardSpawner _cardSpawner;

    [Header("Stats")]
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Timer _timer;

    [Header("UI")]
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _toMenuButton;

    private Game _game;
    private ScenesLoader _scenesLoader;
    private PlayerProgress _playerProgress;

    [Inject]
    public void Construct(PlayerProgress playerProgress) {
        _playerProgress = playerProgress;
    }

    public override void InstallBindings() {
        _scenesLoader = new ScenesLoader(_settings.Mode, _scoreCounter);
        _game = new Game(
            _lifeCounter,
            _scenesLoader,
            _gameOverPanel,
            _settings,
            _playerProgress,
            _scoreCounter,
            _continueButton,
            _pauseButton,
            _toMenuButton
        );

        BindInstanceSingle<Game>(_game);
        BindInstanceSingle<ScenesLoader>(_scenesLoader);

        BindInstanceSingle<GameplaySettings>(_settings);
        BindInstanceSingle<ClassicGameplaySettings>(_settings);

        BindInstanceSingle<AnswerHandler>(_answerHandler);
        BindInstanceSingle<CardDragger>(_cardDragger);
        BindInstanceSingle<FigureGenerator>(_figureGenerator);
        BindInstanceSingle<CardSpawner>(_cardSpawner);

        BindInstanceSingle<LifeCounter>(_lifeCounter);
        BindInstanceSingle<ScoreCounter>(_scoreCounter);
        BindInstanceSingle<Timer>(_timer);
    }

    private T BindInstanceSingle<T>(T instance) {
        Container
            .BindInstance<T>(instance)
            .AsSingle()
            .NonLazy();
        return instance;
    }
}