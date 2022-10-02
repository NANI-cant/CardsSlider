using System;
using UnityEngine;
using UnityEngine.Audio;
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
    private AudioMixer _audioMixer;
    private IInputService _inputService;
    private DynamicMusic _dynamicMusic;

    [Inject]
    public void Construct(PlayerProgress playerProgress, AudioMixer audioMixer) {
        _playerProgress = playerProgress;
        _audioMixer = audioMixer;
    }

    public override void InstallBindings() {
        _scenesLoader = new ScenesLoader(_settings.Mode, _scoreCounter);
        _inputService = new PointerInput();
        _game = new Game(
            _lifeCounter,
            _scenesLoader,
            _gameOverPanel,
            _settings,
            _playerProgress,
            _scoreCounter,
            _continueButton,
            _pauseButton,
            _toMenuButton,
            _inputService
        );
        _dynamicMusic = new DynamicMusic(_audioMixer, _scoreCounter, _settings, _game);

        BindInstanceSingle<Game>(_game);
        BindInstanceSingle<IInputService>(_inputService);
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

    private void OnDestroy() {
        (_inputService as IDisposable).Dispose();
    }

    private T BindInstanceSingle<T>(T instance) {
        Container
            .BindInstance<T>(instance)
            .AsSingle()
            .NonLazy();
        return instance;
    }

}