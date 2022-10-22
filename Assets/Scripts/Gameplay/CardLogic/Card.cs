using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CardMover))]
[RequireComponent(typeof(CardView))]
public class Card : MonoBehaviour {
    [Header("Show Tween")]
    [SerializeField] private float _showDuration = 0.3f;
    [SerializeField] private float _startScale = 0.4f;

    [Header("HideTween")]
    [SerializeField] private float _hideDuration = 0.5f;

    private List<FigureData> _figures;
    private CardMover _mover;
    private CardView _view;
    private Sequence _tweenSequence;

    public CardMover Mover => _mover;
    public IEnumerable<FigureData> Figures => _figures;

    private void Awake() {
        _mover = GetComponent<CardMover>();
        _view = GetComponent<CardView>();
    }

    private void Start() => Show();
    private void OnDestroy() => _tweenSequence?.Kill();

    public void Initialize(List<FigureData> figures) {
        _figures = figures;
        _view.Visualize(figures);
    }

    public void Hide(bool answerResult) {
        _tweenSequence?.Complete();

        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        Color hidingColor = answerResult ? Color.green : Color.red;
        hidingColor.a = 0f;

        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Append(transform.DOScale(Vector3.zero, _hideDuration));
        foreach (var renderer in renderers) {
            renderer.sortingOrder -= 2;
            _tweenSequence.Join(renderer.DOColor(hidingColor, _hideDuration));
        }

        Invoke(nameof(ExecuteDestroy), _hideDuration);
    }

    private void Show() {
        _tweenSequence?.Complete();

        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        transform.localScale = Vector3.one * _startScale;

        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Append(transform.DOScale(Vector3.one, _showDuration));
        foreach (var renderer in renderers) {
            Color showingColor = renderer.color;
            showingColor.a = 1;
            Color transparentColor = showingColor;
            transparentColor.a = 0f;

            renderer.color = transparentColor;
            _tweenSequence.Join(renderer.DOColor(showingColor, _showDuration));
        }
    }

    private void ExecuteDestroy() => Destroy(gameObject);
}
