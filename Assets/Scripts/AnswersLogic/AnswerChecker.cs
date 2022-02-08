﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum Answer {
    Yes,
    No
}

public class AnswerChecker : MonoBehaviour {
    [SerializeField] private Answer _kindOfAnswer;
    [SerializeField] private float _checkRadius;
    [SerializeField] private CardDragger _cardDragger;
    [SerializeField] private FigureGenerator _figureGenerator;
    [Header("Debug")]
    [SerializeField] private Color _debugColor;

    private string _targetId;

    public static UnityAction<bool> OnAnswerCheck;

    private void OnValidate() {
        if (_checkRadius < 0) _checkRadius = 0;
    }

    private void OnEnable() {
        _cardDragger.OnCardDrop += Check;
        _figureGenerator.OnFigureGenerated += SetTarget;
    }

    private void OnDisable() {
        _cardDragger.OnCardDrop -= Check;
        _figureGenerator.OnFigureGenerated -= SetTarget;
    }

    private void Check(Card card) {
        if (!IsCardNear(card.transform.position)) { return; }
        card.Destroy();

        bool isFigureOnCard = false;
        foreach (var figure in card.Figures) {
            if (figure.Id == _targetId) {
                isFigureOnCard = true;
                break;
            }
        }

        Debug.Log("Answer " + (isFigureOnCard == (_kindOfAnswer == Answer.Yes)));
        OnAnswerCheck?.Invoke(isFigureOnCard == (_kindOfAnswer == Answer.Yes));
    }

    private void SetTarget(FigureData figure) {
        _targetId = figure.Id;
    }

    private bool IsCardNear(Vector2 cardPosition) => Mathf.Sqrt(((Vector2)transform.position - cardPosition).sqrMagnitude) <= _checkRadius;

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
}
