using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject {
    [Range(0, 100)]
    [SerializeField] private float _volume;
    [SerializeField] public FiguresCollection SelectedFiguresCollection;
    [SerializeField] public int SelectedLanguage;


    public float Volume {
        get { return _volume; }
        set {
            float rightValue = Mathf.Max(0f, value);
            rightValue = Mathf.Min(rightValue, 100f);
            _volume = rightValue;
        }
    }
}
