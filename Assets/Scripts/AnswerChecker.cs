using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

enum Answer {
    Yes,
    No
}

public class AnswerChecker : MonoBehaviour {
    [SerializeField] private CardDragger _cardDrager;
    [SerializeField] private Answer _kindOfAnswer;
    [SerializeField] private float _checkRadius;
    [Header("Debug")]
    [SerializeField] private Color _debugColor;

    public string TargetId;
    public UnityAction<bool> OnAnswerCheck;

    private void OnEnable() {
        _cardDrager.OnCardDrop += Check;
    }

    private void OnDisable() {
        _cardDrager.OnCardDrop -= Check;
    }

    public void Check(Card card) {
        if (!IsCardNear(card.transform.position)) { return; }
        card.Destroy();

        bool isFigureOnCard = false;
        foreach (var figure in card.Figures) {
            if (figure.Id == TargetId) {
                isFigureOnCard = true;
                break;
            }
        }

        Debug.Log("Answer " + (isFigureOnCard == (_kindOfAnswer == Answer.Yes)));
        OnAnswerCheck?.Invoke(isFigureOnCard == (_kindOfAnswer == Answer.Yes));
    }

    private bool IsCardNear(Vector2 cardPosition) => Mathf.Sqrt(((Vector2)transform.position - cardPosition).sqrMagnitude) <= _checkRadius;

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;
        Gizmos.DrawWireSphere(transform.position, _checkRadius);
    }
}
