using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CardMover))]
[RequireComponent(typeof(CardView))]
public class Card : MonoBehaviour {
    private List<FigureData> _figures;

    private CardMover _mover;
    private CardView _view;

    public CardMover Mover => _mover;
    public IEnumerable<FigureData> Figures => _figures;

    private void Awake() {
        _mover = GetComponent<CardMover>();
        _view = GetComponent<CardView>();
    }

    public void Initialize(List<FigureData> figures) {
        _figures = figures;
        _view.Visualize(figures);
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}
