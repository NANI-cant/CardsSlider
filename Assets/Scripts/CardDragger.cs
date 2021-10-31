using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CardDragger : MonoBehaviour {
    [SerializeField] Camera camera;
    [SerializeField] LayerMask whatIsCard;

    private Card holdingCard;

    private Inputs inputs;
    private Vector2 distanceToPointer;

    public UnityAction<AnswerResult> OnCardDrop;

    private Vector2 pointerPosition => camera.ScreenToWorldPoint(inputs.CardDragger.Dragging.ReadValue<Vector2>());

    private void Awake() {
        inputs = new Inputs();
    }

    private void OnEnable() {
        inputs.Enable();
        inputs.CardDragger.TakeDrop.started += ctx => TakeCard();
        inputs.CardDragger.TakeDrop.canceled += ctx => DropCard();
    }

    private void OnDisable() {
        inputs.Disable();
    }

    private void FixedUpdate() {
        DragCard();
    }

    private void DragCard() {
        if (holdingCard == null) { return; }

        holdingCard.transform.position = pointerPosition - distanceToPointer;
    }

    private void TakeCard() {
        RaycastHit2D hitResult = Physics2D.Raycast(pointerPosition, Vector2.zero, float.MaxValue, whatIsCard);
        if (hitResult.collider != null) {
            holdingCard = hitResult.collider.GetComponent<Card>();
            holdingCard.Mover.CanMove = false;
            distanceToPointer = pointerPosition - (Vector2)holdingCard.transform.position;
            Debug.Log("Card Taked");
        }
        else {
            holdingCard = null;
        }
    }

    private void DropCard() {
        if (holdingCard == null) { return; }

        Debug.Log("Card Dropped");
        holdingCard.Mover.CanMove = true;
        AnswerResult result = new AnswerResult(holdingCard.transform.position, holdingCard);
        holdingCard = null;
        OnCardDrop?.Invoke(result);
    }
}