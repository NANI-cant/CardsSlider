using DG.Tweening;
using UnityEngine;

public class MovableCardFigure : MonoBehaviour {
    [SerializeField] private Vector3 _endPosition;

    private RectTransform _rectTransform;
    private Vector3 _startScale;

    private const float FIRST_DURATION_ANIMATION = 0.5f;
    private const float SECOND_DURATION_ANIMATION = 0.7f;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        _startScale = _rectTransform.localScale;
    }

    public void RotateAndScale() {
        _rectTransform.DORotate(_endPosition, FIRST_DURATION_ANIMATION).SetEase(Ease.OutCubic);
        _rectTransform.DOScale(_endPosition, SECOND_DURATION_ANIMATION).SetEase(Ease.OutCubic);
    }

    public void StartAnimation(){
        _rectTransform.DORotate(_endPosition, 0f);
        _rectTransform.DOScale(_endPosition, 0f);

        _rectTransform.DORotate(new Vector3(0f, 0f, -16f), SECOND_DURATION_ANIMATION).SetEase(Ease.OutCubic);
        _rectTransform.DOScale(_startScale, FIRST_DURATION_ANIMATION).SetEase(Ease.OutCubic);
    }
}
