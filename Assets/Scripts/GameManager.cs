using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Lifes")]
    [SerializeField] private uint _startLifes;

    [Header("Figure Generating")]
    [SerializeField] private uint _maxFiguresCount;
    [SerializeField] private uint _startFiguresCount;
    [SerializeField] private uint _answersForAddFigure;

    private LifeCounter _life;

    private void Awake() {
        ServiceLocator.RegisterService<GameManager>(this);
        _life = ServiceLocator.GetService<LifeCounter>();
        _life.Initialize((int)_startLifes);
        ServiceLocator.GetService<FigureGenerator>().Initialize((int)_startFiguresCount, (int)_maxFiguresCount, (int)_answersForAddFigure);
    }

    private void OnEnable() {
        _life.OnLifesOver += EndGame;
    }

    private void OnDisable() {
        _life.OnLifesOver -= EndGame;
    }

    private void EndGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
