using UnityEngine;
using Zenject;

public class AnswerHandler : MonoBehaviour {
    private float _settingTime;
    private int _addingScore;
    private int _takingLifes;
    private GameMode _gameMode;

    private Timer _timer;
    private LifeCounter _life;
    private ScoreCounter _score;
    private ClassicGameplaySettings _settings;

    [Inject]
    public void Construct(Timer timer, LifeCounter lifeCounter, ScoreCounter scoreCounter, ClassicGameplaySettings settings) {
        _timer = timer;
        _life = lifeCounter;
        _score = scoreCounter;

        _settings = settings;
        _gameMode = settings.Mode;
        _addingScore = settings.AddingScore;
        _takingLifes = settings.TakingLifes;
        _settingTime = settings.SettingTimeOverScore(scoreCounter.Score);
    }

    private void OnEnable() {
        AnswerChecker.AnswerChecked += ReactToAnswer;
        _score.ScoreChanged += OnScoreChanged;
        _timer.OnTimesUp += OnTimesUp;
    }

    private void OnDisable() {
        AnswerChecker.AnswerChecked -= ReactToAnswer;
        _score.ScoreChanged -= OnScoreChanged;
        _timer.OnTimesUp -= OnTimesUp;
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

    private void OnTimesUp() => ReactToAnswer(false);
    private void OnScoreChanged(int newScore) => _settingTime = _settings.SettingTimeOverScore(newScore);
}
