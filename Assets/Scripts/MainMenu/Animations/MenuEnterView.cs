using DG.Tweening;
using UnityEngine;

public class MenuEnterView : MonoBehaviour {
    [SerializeField] private MovableFigure[] _figures;
    [SerializeField] private MovableCardFigure _card;
    [SerializeField] private CanvasGroup[] _canvasesFade;

    private const float FadeDuration = 0.4f;

    private Sequence _tweenSequence;

    private void Start() {
        _tweenSequence = DOTween.Sequence();
        foreach (CanvasGroup canvas in _canvasesFade) {
            canvas.alpha = 0;
            _tweenSequence.Join(canvas.DOFade(1, FadeDuration));
        }

        foreach (MovableFigure figure in _figures) {
            figure.StartMove();
        }

        _card.AnimateSceneEnter();
    }

    private void OnDestroy() => _tweenSequence?.Kill();
}
