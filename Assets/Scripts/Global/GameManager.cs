using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Game Mode")]
    [SerializeField] private Mode _gameMode = Mode.Classic;

    [Header("Lifes")]
    [SerializeField] private int _startLifes;

    [Header("Figure Generating")]
    [SerializeField] private int _maxFiguresCount;
    [SerializeField] private int _startFiguresCount;
    [SerializeField] private int _answersForAddFigure;

    [SerializeField] private LifeCounter _life;
    [SerializeField] private ScoreCounter _score;

    private void OnValidate(){
        if (_startLifes < 1) _startLifes = 1;
        if (_startFiguresCount < 1) _startFiguresCount = 1;
        if (_maxFiguresCount < 1) _maxFiguresCount = 1;
        if (_answersForAddFigure < 1) _answersForAddFigure = 1;
    }

    private void Awake() {
        _life.Initialize(_startLifes);
        FindObjectOfType<FigureGenerator>().Initialize(_startFiguresCount, _maxFiguresCount, _answersForAddFigure);
        FindObjectOfType<AnswerHandler>().Initialize(_gameMode);
    }

    public void ExitGame() {
        EndGameResult endGameResult = new EndGameResult(_gameMode, _score.Score);
        MainMenu.Load(endGameResult);
    }
}
