using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject {
    [Range(0, 1)]
    [SerializeField] private float _musicVolume;
    [Range(0, 1)]
    [SerializeField] private float _soundsVolume; 
    [SerializeField] public FiguresCollection SelectedFiguresCollection;
    [SerializeField] public int SelectedLanguage;


    public float MusicVolume {
        get { return _musicVolume; }
        set {
            float rightValue = Mathf.Max(0f, value);
            rightValue = Mathf.Min(rightValue, 100f);
            _musicVolume = rightValue;
        }
    }

    public float SoundsVolume {
        get { return _soundsVolume; }
        set {
            float rightValue = Mathf.Max(0f, value);
            rightValue = Mathf.Min(rightValue, 100f);
            _soundsVolume = rightValue;
        }
    }
}
