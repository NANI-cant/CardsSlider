using DG.Tweening;
using UnityEngine;

public class SceneEntryAnimation : MonoBehaviour {
    [Header("Layouts")]
    [SerializeField] private RectTransform _timer;
    [SerializeField] private RectTransform _lifes;
    [SerializeField] private RectTransform _score;
    [SerializeField] private RectTransform _pauseButton;
    [SerializeField] private CanvasGroup _hud;

    [Header("Settings")]
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private float _durationAnimation;

    private Sequence _tweenSequence;

    private void Start() {
        Prepare();
        Execute();
    }

    private void OnDestroy() => _tweenSequence?.Kill();

    private void Prepare() {
        _timer.localScale = _startScale;
        _lifes.localScale = _startScale;
        _score.localScale = _startScale;
        _pauseButton.localScale = _startScale;
        _hud.alpha = 0;
    }

    private void Execute() {
        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Join(_score.DOScale(_endScale, _durationAnimation));
        _tweenSequence.Join(_lifes.DOScale(_endScale, _durationAnimation));
        _tweenSequence.Join(_pauseButton.DOScale(_endScale, _durationAnimation));
        _tweenSequence.Join(_timer.DOScale(_endScale, _durationAnimation));
        _tweenSequence.Join(_hud.DOFade(1, _durationAnimation));
    }
}
