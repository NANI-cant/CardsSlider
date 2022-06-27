﻿using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CardMover))]
[RequireComponent(typeof(CardView))]
public class Card : MonoBehaviour {
    private const float HIDEDURATION = 0.5f;

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

    public void Hide(bool answerResult) {
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();

        Color hidingColor = answerResult ? Color.green : Color.red;
        hidingColor.a = 0f;

        foreach (var renderer in renderers) {
            renderer.sortingOrder -= 2;
            renderer.DOColor(hidingColor, HIDEDURATION);
        }
        transform.DOScale(Vector3.zero, HIDEDURATION);

        Invoke(nameof(ExecuteDestroy), HIDEDURATION + 0.01f);
    }

    private void ExecuteDestroy() => Destroy(gameObject);
}
