using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Mode {
    Classic,
    Arcade,
    Hard,
    Relax,
}

public class AnswerHandler : MonoBehaviour {
    [SerializeField] private Mode _gameMode = Mode.Classic;

    [Header("Classic")]
    [SerializeField] private float _settingTime;
    [SerializeField] private float _addingScore;
    [SerializeField] private uint _takingLifes;

    [Header("References")]
    [SerializeField] private Timer _timer;
    [SerializeField] private AnswerChecker _yesCheck;
    [SerializeField] private AnswerChecker _noCheck;

    private void OnEnable() {
        _yesCheck.OnAnswerCheck += ReactToAnswer;
        _noCheck.OnAnswerCheck += ReactToAnswer;
    }

    private void OnDisable() {
        _yesCheck.OnAnswerCheck -= ReactToAnswer;
        _noCheck.OnAnswerCheck -= ReactToAnswer;
    }

    private void ReactToAnswer(bool answer) {
        _timer.Run();
        switch (_gameMode) {
            case Mode.Classic: {
                    _timer.Set(_settingTime);
                    break;
                }
            default: {
                    break;
                }
        }
    }
}
