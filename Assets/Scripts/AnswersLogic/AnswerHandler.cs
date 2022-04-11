using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class AnswerHandler : MonoBehaviour {
    [SerializeField] private GameMode _gameMode = GameMode.Classic;

    [Header("Classic")]
    [Min(0)][SerializeField] private float _settingTime;
    [Min(0)][SerializeField] private int _addingScore;
    [Min(0)][SerializeField] private int _takingLifes;

    private Timer _timer;
    private LifeCounter _life;
    private ScoreCounter _score;

    private UnityAction _reactFalse;

    [Inject]
    public void Construct(Timer timer, LifeCounter lifeCounter, ScoreCounter scoreCounter, ClassicGameplaySettings settings) {
        _timer = timer;
        _life = lifeCounter;
        _score = scoreCounter;

        _gameMode = settings.Mode;
        _settingTime = settings.SettingTime;
        _addingScore = settings.AddingScore;
        _takingLifes = settings.TakingLifes;
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
            case GameMode.Classic: {
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
