using UnityEngine;
using DG.Tweening;

public class MovableCardFigure : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    private RectTransform _rectTransform;

    private void Awake() {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void RotateAndScale(){
        _rectTransform.DORotate(_endPosition, 0.5f);
        _rectTransform.DOScale(_endPosition, 0.7f);
    }
}
