using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerChecker : MonoBehaviour {
    [SerializeField] private CardDragger cardDrager;
    [SerializeField] private bool kindOfAnswer;
    [SerializeField] private float checkRadius;
    [Header("Debug")]
    [SerializeField] private Color debugColor;

    public string targetId;
    public UnityAction<bool> OnAnswerCheck;

    private void OnEnable() {
        cardDrager.OnCardDrop += Check;
    }

    private void OnDisable() {
        cardDrager.OnCardDrop -= Check;
    }

    public void Check(Card card) {
        if (!IsCardNear(card.transform.position)) { return; }
        card.Destroy();

        bool isFigureOnCard = false;
        foreach (var figure in card.Figures) {
            if (figure.Id == targetId) {
                isFigureOnCard = true;
                break;
            }
        }

        Debug.Log("Answer " + (isFigureOnCard == kindOfAnswer));
        OnAnswerCheck?.Invoke(isFigureOnCard == kindOfAnswer);
    }

    private bool IsCardNear(Vector2 cardPosition) => Mathf.Sqrt(((Vector2)transform.position - cardPosition).sqrMagnitude) <= checkRadius;

    private void OnDrawGizmos() {
        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
