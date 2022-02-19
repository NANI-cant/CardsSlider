using UnityEngine;
using UnityEngine.Events;

public enum Mode {
    Classic,
    Arcade,
    Hard,
    Relax,
}

public class AnswerHandler : MonoBehaviour {
    [SerializeField] private Mode _gameMode = Mode.Classic;

    [Header("Classic")]
    [SerializeField] private float _settingTime;
    [SerializeField] private int _addingScore;
    [SerializeField] private int _takingLifes;
    [Header("")]
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private LifeCounter _life;
    [SerializeField] private Timer _timer;

    private UnityAction _reactFalse;

    private void OnValidate() {
        if (_settingTime < 0) _settingTime = 0;
        if (_addingScore < 0) _addingScore = 0;
        if (_takingLifes < 0) _takingLifes = 0;
    }

    public void Initialize(Mode gameMode) {
        _gameMode = gameMode;
    }

    private void OnEnable() {
        AnswerChecker.OnAnswerCheck += ReactToAnswer;
        _reactFalse = () => ReactToAnswer(false);
        _timer.OnTimesUp += _reactFalse;
    }

    private void OnDisable() {
        AnswerChecker.OnAnswerCheck -= ReactToAnswer;
        _timer.OnTimesUp -= _reactFalse;
    }

    private void ReactToAnswer(bool answer) {
        _timer.Set(_settingTime);
        _timer.Run();
        switch (_gameMode) {
            case Mode.Classic: {
                    if (answer) {
                        _timer.Set(_settingTime);
                        _score.Add(_addingScore);
                    }
                    else {
                        _life.TryToTake(_takingLifes);
                    }
                    break;
                }
            default: {
                    break;
                }
        }
    }
}
