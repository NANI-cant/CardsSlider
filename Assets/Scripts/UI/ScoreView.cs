using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour {
    [SerializeField] private PunchOptions _punch;

    private TextMeshProUGUI _uGUI;
    private ScoreCounter _scoreModel;

    [Inject]
    public void Construct(ScoreCounter scoreCounter) {
        _scoreModel = scoreCounter;
    }

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        _scoreModel.OnScoreChanged += ChangeUI;
    }

    private void OnDisable() {
        _scoreModel.OnScoreChanged -= ChangeUI;
    }

    private void Start() {
        ChangeUI(_scoreModel.Score);
    }

    private void ChangeUI(int score) {
        _uGUI.text = score.ToString();
        ExecuteTweening();
    }

    private void ExecuteTweening() {
        transform.DOPunchScale(_punch.Punch, _punch.Duration, _punch.Vibrato, _punch.Elacticity);
    }
}
