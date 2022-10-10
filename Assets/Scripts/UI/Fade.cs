using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour {
    [Min(0)][SerializeField] private float _fadeDuration;

    private CanvasGroup _canvasGroup;
    private Tweener _tweener;

    private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();
    private void OnDestroy() => _tweener?.Kill();

    public void Show() {
        _tweener?.Complete();
        _tweener = _canvasGroup.DOFade(1, _fadeDuration);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide() {
        _tweener?.Complete();
        _tweener = _canvasGroup.DOFade(0, _fadeDuration);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
