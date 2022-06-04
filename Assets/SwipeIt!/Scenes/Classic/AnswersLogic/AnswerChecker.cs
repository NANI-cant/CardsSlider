using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;


public class AnswerChecker : MonoBehaviour {
    [SerializeField] private Answer _kindOfAnswer;
    [SerializeField][Min(0)] private float _checkRadius;
    [Header("Debug")]
    [SerializeField] private bool _shouldLog = false;

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

        this.Do(() => Debug.Log("Answer " + (isFigureOnCard == (_kindOfAnswer == Answer.Yes))), when: _shouldLog);
        OnAnswerCheck?.Invoke(isFigureOnCard == (_kindOfAnswer == Answer.Yes));
    }

    private void Do(object v, object when) {
        throw new NotImplementedException();
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

    enum Answer {
        Yes,
        No
    }
}
