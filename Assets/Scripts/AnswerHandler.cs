using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

enum Mode {
    Classic,
    Arcade,
    Hard,
    Relax,
}

public class AnswerHandler : MonoBehaviour {
    [SerializeField] private Mode _gameMode = Mode.Classic;
    [SerializeField] private uint _currentLifes = 3;

    [Header("Classic")]
    [SerializeField] private float _settingTime;
    [SerializeField] private uint _addingScore;
    [SerializeField] private uint _takingLifes;

    [Header("References")]
    [SerializeField] private Timer _timer;
    [SerializeField] private AnswerChecker _yesCheck;
    [SerializeField] private AnswerChecker _noCheck;
    [SerializeField] private ScoreVisualizer _scoreUI;
    [SerializeField] private LifesVisualizer _lifesUI;

    public UnityAction OnLifesEnd;

    private uint _currentScore = 0;
    private UnityAction reactFalse;

    public uint Score => _currentScore;

    private void Awake() {
        _lifesUI.Visualize(_currentLifes);
        _scoreUI.Visualize(_currentScore);
    }

    private void OnEnable() {
        _yesCheck.OnAnswerCheck += ReactToAnswer;
        _noCheck.OnAnswerCheck += ReactToAnswer;
        reactFalse = () => ReactToAnswer(false);
        _timer.OnTimesUp += reactFalse;
    }

    private void OnDisable() {
        _yesCheck.OnAnswerCheck -= ReactToAnswer;
        _noCheck.OnAnswerCheck -= ReactToAnswer;
        _timer.OnTimesUp -= reactFalse;
    }

    private void ReactToAnswer(bool answer) {
        _timer.Set(_settingTime);
        _timer.Run();
        switch (_gameMode) {
            case Mode.Classic: {
                    if (answer) {
                        _timer.Set(_settingTime);
                        GiveScore(_addingScore);
                    }
                    else {
                        TakeLifes(_takingLifes);
                    }
                    break;
                }
            default: {
                    break;
                }
        }
    }

    private void GiveScore(uint score) {
        _currentScore += score;
        _scoreUI.Visualize(_currentScore);
    }

    private void TakeLifes(uint lifes) {
        if (_currentLifes == 0) {
            return;
        }

        _currentLifes -= lifes;
        _lifesUI.Visualize(_currentLifes);

        if (_currentLifes == 0) {
            OnLifesEnd?.Invoke();
        }
    }
}
