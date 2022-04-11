using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameplaySettings/Classic")]
public class ClassicGameplaySettings : GameplaySettings {
    [Header("Gameplay")]
    [Min(0)][SerializeField] private float _settingTime = 3f;
    [Min(0)][SerializeField] private int _addingScore = 1;
    [Min(0)][SerializeField] private int _takingLifes = 1;

    public override GameMode Mode => GameMode.Classic;
    public float SettingTime => _settingTime;
    public int AddingScore => _addingScore;
    public int TakingLifes => _takingLifes;
}