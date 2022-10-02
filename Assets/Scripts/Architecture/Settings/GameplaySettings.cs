using UnityEngine;

public enum GameMode {
    Classic,
    Arcade,
    Hard,
    Relax,
}

[CreateAssetMenu(menuName = "ScriptableObjects/GameplaySettings")]
public abstract class GameplaySettings : ScriptableObject {
    [Header("Base")]
    [Min(0)][SerializeField] private float _startTime = 3f;
    [Min(1)][SerializeField] private int _startLifes = 3;
    [Range(0, 1)][SerializeField] private float _convertMultiplier = 0.5f;

    [Header("Card Generating")]
    [Min(1)][SerializeField] private int _startFiguresCount = 1;
    [Min(1)][SerializeField] private int _maxFiguresCount = 8;
    [Min(1)][SerializeField] private int _answersForAddFigure = 3;

    [Header("Audio")]
    [SerializeField] private AnimationCurve _musicSpeedOverScore;

    public float StartTime => _startTime;
    public int StartLifes => _startLifes;
    public float ConvertMultiplier => _convertMultiplier;

    public int StartFiguresCount => _startFiguresCount;
    public int MaxFiguresCount => _maxFiguresCount;
    public int AnswersForAddFigure => _answersForAddFigure;

    public abstract GameMode Mode { get; }

    public float MusicSpeedOverScore(int score) => _musicSpeedOverScore.Evaluate(score);

    protected virtual void OnValidate() {
        if (_startFiguresCount > _maxFiguresCount) _startFiguresCount = _maxFiguresCount;
    }
}
