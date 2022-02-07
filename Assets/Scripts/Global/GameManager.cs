using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Game Mode")]
    [SerializeField] private Mode _gameMode;

    [Header("Lifes")]
    [SerializeField] private uint _startLifes;

    [Header("Figure Generating")]
    [SerializeField] private uint _maxFiguresCount;
    [SerializeField] private uint _startFiguresCount;
    [SerializeField] private uint _answersForAddFigure;

    private LifeCounter _life;
    private ScoreCounter _score;

    private void Awake() {
        ServiceLocator.RegisterService<GameManager>(this);
        _score = ServiceLocator.GetService<ScoreCounter>();
        _life = ServiceLocator.GetService<LifeCounter>();
        _life.Initialize((int)_startLifes);
        ServiceLocator.GetService<FigureGenerator>().Initialize((int)_startFiguresCount, (int)_maxFiguresCount, (int)_answersForAddFigure);
        ServiceLocator.GetService<AnswerHandler>().Initialize(_gameMode);
    }

    private void OnEnable() {
        //_life.OnLifesOver += EndGame;
    }

    private void OnDisable() {
        //_life.OnLifesOver -= EndGame;
    }

    public void EndGame() {
        EndGameResult endGameResult = new EndGameResult(_gameMode, _score.Score);
        MainMenu.Load(endGameResult);
    }
}
