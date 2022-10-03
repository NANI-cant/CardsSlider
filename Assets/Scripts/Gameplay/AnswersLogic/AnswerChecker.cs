using System;
using UnityEngine;
using Zenject;

public class AnswerChecker : MonoBehaviour {
    enum Answer {
        Yes,
        No
    }

    [SerializeField] private Answer _kindOfAnswer;
    [SerializeField][Min(0)] private float _checkRadius;
    [Header("Debug")]
    [SerializeField] private bool _shouldLog = false;

    public static event Action<bool> AnswerChecked;

    private CardDragger _cardDragger;
    private FigureGenerator _figureGenerator;
    private string _targetId;

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

        bool isFigureOnCard = false;
        foreach (var figure in card.Figures) {
            if (figure.Id == _targetId) {
                isFigureOnCard = true;
                break;
            }
        }

        bool answerResult = isFigureOnCard == (_kindOfAnswer == Answer.Yes);
        AnswerChecked?.Invoke(answerResult);
        card.Hide(answerResult);

        this.Do(() => Debug.Log($"Answer {answerResult}"), when: _shouldLog);
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
