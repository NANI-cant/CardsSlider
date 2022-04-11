using UnityEngine;
using Zenject;

public class BootstrapperClassic : MonoInstaller {
    [Header("Static Data")]
    [SerializeField] private ClassicGameplaySettings _settings;

    [Header("Gameplay")]
    [SerializeField] private AnswerHandler _answerHandler;
    [SerializeField] private CardDragger _cardDragger;
    [SerializeField] private FigureGenerator _figureGenerator;

    [Header("Stats")]
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Timer _timer;

    [Header("UI")]
    [SerializeField] private GameOverPanel _gameOverPanel;

    private Game _game;
    private ScenesLoader _scenesLoader;

    public override void InstallBindings() {
        _scenesLoader = new ScenesLoader(_settings.Mode, _scoreCounter);
        _game = new Game(_lifeCounter, _scenesLoader, _gameOverPanel);

        BindInstanceSingle<Game>(_game);
        BindInstanceSingle<ScenesLoader>(_scenesLoader);

        BindInstanceSingle<GameplaySettings>(_settings);
        BindInstanceSingle<ClassicGameplaySettings>(_settings);

        BindInstanceSingle<AnswerHandler>(_answerHandler);
        BindInstanceSingle<CardDragger>(_cardDragger);
        BindInstanceSingle<FigureGenerator>(_figureGenerator);

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