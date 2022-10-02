using UnityEngine.Audio;

public class DynamicMusic {
    private const string MusicPitchKey = "MusicPitch";
    private const string MusicSpeedKey = "MusicSpeed";

    private AudioMixer _mixer;
    private AnswerChecker _checker;
    private GameplaySettings _settings;
    private Game _game;
    private ScoreCounter _score;

    public DynamicMusic(AudioMixer mixer, ScoreCounter score, GameplaySettings settings, Game game) {
        _settings = settings;
        _game = game;
        _score = score;
        _mixer = mixer;

        _score.ScoreChanged += OnScoreChanged;
        _game.GameOvered += OnGameOver;
        _game.GameInterrupted += OnGameOver;
    }

    private void OnGameOver() => SetSpeed(1);
    private void OnScoreChanged(int score) => SetSpeed(_settings.MusicSpeedOverScore(score));

    private void SetSpeed(float speed) {
        float pitch = 1 / speed;

        _mixer.SetFloat(MusicSpeedKey, speed);
        _mixer.SetFloat(MusicPitchKey, pitch);
    }
}
