using UnityEngine;
using Zenject;

public class Bootstrapper : MonoInstaller {
    [SerializeField] private Game _game;
    [SerializeField] private AnswerHandler _answerHandler;
    [SerializeField] private CardDragger _cardDragger;
    [SerializeField] private FigureGenerator _figureGenerator;
    [SerializeField] private LifeCounter _lifeCounter;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Timer _timer;

    public override void InstallBindings() {
        BindInstanceSingle<Game>(_game);
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