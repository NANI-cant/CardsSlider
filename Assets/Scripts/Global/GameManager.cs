using IJunior.TypedScenes;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour {
    [Header("Game Mode")]
    [SerializeField] private Mode _gameMode = Mode.Classic;

    [Header("Lifes")]
    [Min(1)][SerializeField] private int _startLifes;

    [Header("Figure Generating")]
    [Min(1)][SerializeField] private int _maxFiguresCount;
    [Min(1)][SerializeField] private int _startFiguresCount;
    [Min(1)][SerializeField] private int _answersForAddFigure;

    private LifeCounter _life;
    private ScoreCounter _score;
    private FigureGenerator _figureGenerator;
    private AnswerHandler _answerHandler;

    [Inject]
    public void Construct(LifeCounter lifeCounter, ScoreCounter scoreCounter, FigureGenerator figureGenerator, AnswerHandler answerHandler) {
        _life = lifeCounter;
        _score = scoreCounter;
        _figureGenerator = figureGenerator;
        _answerHandler = answerHandler;
    }

    private void Awake() {
        _life.Initialize(_startLifes);
        _figureGenerator.Initialize(_startFiguresCount, _maxFiguresCount, _answersForAddFigure);
        _answerHandler.Initialize(_gameMode);
    }

    public void ExitGame() {
        EndGameResult endGameResult = new EndGameResult(_gameMode, _score.Score);
        MainMenu.Load(endGameResult);
    }
}
