using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour {
    [SerializeField] private PunchOptions _punch;

    private TextMeshProUGUI _uGUI;
    private ScoreCounter _scoreModel;
    private Tweener _tweener;

    [Inject]
    public void Construct(ScoreCounter scoreCounter) {
        _scoreModel = scoreCounter;
    }

    private void Awake() => _uGUI = GetComponent<TextMeshProUGUI>();
    private void OnEnable() => _scoreModel.ScoreChanged += ChangeUI;
    private void OnDisable() => _scoreModel.ScoreChanged -= ChangeUI;
    private void Start() => ChangeUI(_scoreModel.Score);
    private void OnDestroy() => _tweener?.Kill();

    private void ChangeUI(int score) {
        _uGUI.text = score.ToString();
        ExecuteTweening();
    }

    private void ExecuteTweening() {
        _tweener?.Complete();
        _tweener?.Kill();

        _tweener = transform.DOPunchScale(_punch.Punch, _punch.Duration, _punch.Vibrato, _punch.Elacticity);
    }
}
