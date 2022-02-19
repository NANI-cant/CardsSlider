using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour {
    [Header("Game Mode")]
    [SerializeField] private Mode _gameMode = Mode.Classic;

    [Header("Lifes")]
    [SerializeField] private int _startLifes;

    [Header("Figure Generating")]
    [SerializeField] private int _maxFiguresCount;
    [SerializeField] private int _startFiguresCount;
    [SerializeField] private int _answersForAddFigure;

    [Inject] private LifeCounter _life;
    [Inject] private ScoreCounter _score;
    [Inject] private FigureGenerator _figureGenerator;
    [Inject] private AnswerHandler _answerHandler;

    private void OnValidate() {
        if (_startLifes < 1) _startLifes = 1;
        if (_startFiguresCount < 1) _startFiguresCount = 1;
        if (_maxFiguresCount < 1) _maxFiguresCount = 1;
        if (_answersForAddFigure < 1) _answersForAddFigure = 1;
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
