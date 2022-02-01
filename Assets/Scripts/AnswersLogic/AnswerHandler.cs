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

    [Header("Classic")]
    [SerializeField] private float _settingTime;
    [SerializeField] private int _addingScore;
    [SerializeField] private int _takingLifes;

    [Header("References")]
    [SerializeField] private ScoreCounter _score;
    [SerializeField] private LifeCounter _life;

    private Timer _timer;
    private UnityAction _reactFalse;

    private void Awake() {
        ServiceLocator.RegisterService<AnswerHandler>(this);
        _timer = ServiceLocator.GetService<Timer>();
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
                        _life.Take(_takingLifes);
                    }
                    break;
                }
            default: {
                    break;
                }
        }
    }
}
