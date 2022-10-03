using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject {
    [Range(0, 1)]
    [SerializeField] private float _musicVolume;
    [Range(0, 1)]
    [SerializeField] private float _soundsVolume;
    [SerializeField] private AudioMixer _mixer;

    [SerializeField] public FiguresCollection SelectedFiguresCollection;
    [SerializeField] public int SelectedLanguage;

    private const string MusicVolumeKey = "MusicVolume";
    private const string SoundsVolumeKey = "SoundsVolume";

    public float MusicVolume {
        get => _musicVolume;
        set {
            _musicVolume = Mathf.Clamp(value, 0, 1);
            _mixer.SetFloat(MusicVolumeKey, Mathf.Lerp(-60, 0, _musicVolume));
        }
    }

    public float SoundsVolume {
        get => _soundsVolume;
        set {
            _soundsVolume = Mathf.Clamp(value, 0, 1);
            _mixer.SetFloat(SoundsVolumeKey, Mathf.Lerp(-60, 0, _soundsVolume));
        }
    }
}
