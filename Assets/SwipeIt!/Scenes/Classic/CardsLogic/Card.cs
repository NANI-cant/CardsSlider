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

    public CardMover Mover => _mover;
    public IEnumerable<FigureData> Figures => _figures;

    private void Awake() {
        _mover = GetComponent<CardMover>();
        _view = GetComponent<CardView>();
    }

    private void Start() {
        Show();
    }

    public void Initialize(List<FigureData> figures) {
        _figures = figures;
        _view.Visualize(figures);
    }


    public void Hide(bool answerResult) {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        Color hidingColor = answerResult ? Color.green : Color.red;
        hidingColor.a = 0f;

        foreach (var renderer in renderers) {
            renderer.sortingOrder -= 2;
            renderer.DOColor(hidingColor, _hideDuration);
        }
        transform.DOScale(Vector3.zero, _hideDuration);

        Invoke(nameof(ExecuteDestroy), _hideDuration + 0.01f);
    }

    private void Show() {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers) {
            Color showingColor = renderer.color;
            Color transparentColor = showingColor;
            transparentColor.a = 0f;

            renderer.color = transparentColor;
            renderer.DOColor(showingColor, _showDuration);
        }

        transform.localScale = Vector3.one * _startScale;
        transform.DOScale(Vector3.one, _showDuration);
    }

    private void ExecuteDestroy() => Destroy(gameObject);
}
