using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour {
    [SerializeField] private float _fadeDuration;
    private CanvasGroup _canvasGroup;

    private void OnValidate() {
        if (_fadeDuration < 0) _fadeDuration = 0;
    }

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show() {
        _canvasGroup.DOFade(1, _fadeDuration);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Hide() {
        _canvasGroup.DOFade(0, _fadeDuration);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
