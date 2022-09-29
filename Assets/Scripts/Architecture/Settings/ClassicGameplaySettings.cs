using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameplaySettings/Classic")]
public class ClassicGameplaySettings : GameplaySettings {
    [Header("Gameplay")]
    [Min(0)][SerializeField] private int _addingScore = 1;
    [Min(0)][SerializeField] private int _takingLifes = 1;
    [SerializeField] private AnimationCurve _timeOverScore;

    public int AddingScore => _addingScore;
    public int TakingLifes => _takingLifes;
    public float SettingTimeOverScore(int score) {
        return _timeOverScore.Evaluate(score);
    }

    public override GameMode Mode => GameMode.Classic;
}