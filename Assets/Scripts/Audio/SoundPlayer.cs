using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {
    private AudioSource _source;
    private GameplaySettings _settings;
    private Game _game;
    private Timer _timer;

    [Inject]
    public void Construct(GameplaySettings settings, Game game, Timer timer) {
        _settings = settings;
        _game = game;
        _timer = timer;
    }

    private void Awake() => _source = GetComponent<AudioSource>();

    private void OnEnable() {
        AnswerChecker.AnswerChecked += OnAnswerChecked;
        _game.GameOvered += PlayGameOver;
        _timer.OnTimesUp += PlayWrongAnswer;
    }

    private void OnDisable() {
        AnswerChecker.AnswerChecked -= OnAnswerChecked;
        _game.GameOvered -= PlayGameOver;
        _timer.OnTimesUp -= PlayWrongAnswer;
    }

    private void OnAnswerChecked(bool result) {
        if (result) {
            PlayRightAnswer();
        }
        else {
            PlayWrongAnswer();
        }
    }

    public void PlayRightAnswer() => _source.PlayOneShot(_settings.RightAnswerSound);
    public void PlayWrongAnswer() => _source.PlayOneShot(_settings.WrongAnswerSound);
    public void PlayGameOver() => _source.PlayOneShot(_settings.GameOverSound);
}
