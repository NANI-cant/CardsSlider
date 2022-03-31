﻿using UnityEngine;
using UnityEngine.Events;
using Zenject;

enum Answer {
    Yes,
    No
}

public class AnswerChecker : MonoBehaviour {
    [SerializeField] private Answer _kindOfAnswer;
    [Min(0)]
    [SerializeField] private float _checkRadius;

    private CardDragger _cardDragger;
    private FigureGenerator _figureGenerator;

    private string _targetId;

    public static UnityAction<bool> OnAnswerCheck;

    [Inject]
    public void Construct(CardDragger cardDragger, FigureGenerator figureGenerator) {
        _cardDragger = cardDragger;
        _figureGenerator = figureGenerator;
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
        if (_kindOfAnswer == Answer.Yes) {
            Gizmos.color = Color.green;
        }
        else {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
}
