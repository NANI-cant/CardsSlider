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

    public UnityAction OnAnswerCheck;

    private void OnEnable() {
        cardDrager.OnCardDrop += Check;
    }

    private void OnDisable() {
        cardDrager.OnCardDrop -= Check;
    }

    public void Check(AnswerResult answerResult) {
        if (!IsCardNear(answerResult.CardPosition)) {
            Debug.Log("Card dont near");
            return;
        }

        Debug.Log("Card near");
        answerResult.Card.Destroy();
        Debug.Log("Answer " + kindOfAnswer);
        OnAnswerCheck?.Invoke(); // пока просто удаляем и говорим что проверили
    }

    private bool IsCardNear(Vector2 cardPosition) => Mathf.Sqrt(((Vector2)transform.position - cardPosition).sqrMagnitude) <= checkRadius;

    private void OnDrawGizmos() {
        Gizmos.color = debugColor;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
