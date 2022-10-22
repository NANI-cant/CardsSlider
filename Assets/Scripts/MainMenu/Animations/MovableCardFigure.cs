using DG.Tweening;
using UnityEngine;

public class MovableCardFigure : MonoBehaviour {
    [SerializeField] private Vector3 _endPosition;

    private const float FirstDurationAnimation = 0.5f;
    private const float SecondDurationAnimation = 0.7f;

    private RectTransform _rectTransform;
    private Vector3 _startScale;
    private Sequence _tweenSequence;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _startScale = _rectTransform.localScale;
    }

    private void OnDestroy() => _tweenSequence?.Kill();

    public void AnimateSceneExit() {
        _tweenSequence?.Complete();
        _tweenSequence?.Kill();

        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Join(_rectTransform.DORotate(_endPosition, FirstDurationAnimation).SetEase(Ease.OutCubic));
        _tweenSequence.Join(_rectTransform.DOScale(_endPosition, SecondDurationAnimation).SetEase(Ease.OutCubic));
    }

    public void AnimateSceneEnter() {
        _tweenSequence?.Complete();
        _tweenSequence?.Kill();

        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Join(_rectTransform.DORotate(_endPosition, 0f));
        _tweenSequence.Join(_rectTransform.DOScale(_endPosition, 0f));

        _tweenSequence.Join(_rectTransform.DORotate(new Vector3(0f, 0f, -16f), SecondDurationAnimation).SetEase(Ease.OutCubic));
        _tweenSequence.Join(_rectTransform.DOScale(_startScale, FirstDurationAnimation).SetEase(Ease.OutCubic));
    }
}
