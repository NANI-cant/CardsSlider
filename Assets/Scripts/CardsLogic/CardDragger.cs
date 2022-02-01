using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CardDragger : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _whatIsCard;

    private Card _holdingCard;

    private Inputs _inputs;
    private Vector2 _distanceToPointer;

    public UnityAction<Card> OnCardDrop;

    private Vector2 pointerPosition => _camera.ScreenToWorldPoint(_inputs.CardDragger.Dragging.ReadValue<Vector2>());

    private void Awake() {
        ServiceLocator.RegisterService<CardDragger>(this);
        _inputs = new Inputs();
    }

    private void OnEnable() {
        _inputs.Enable();
        _inputs.CardDragger.TakeDrop.started += ctx => TakeCard();
        _inputs.CardDragger.TakeDrop.canceled += ctx => DropCard();
    }

    private void OnDisable() {
        _inputs.Disable();
    }

    private void FixedUpdate() {
        DragCard();
    }

    private void DragCard() {
        if (_holdingCard == null) { return; }

        _holdingCard.transform.position = pointerPosition - _distanceToPointer;
    }

    private void TakeCard() {
        RaycastHit2D hitResult = Physics2D.Raycast(pointerPosition, Vector2.zero, float.MaxValue, _whatIsCard);
        if (hitResult.collider != null) {
            _holdingCard = hitResult.collider.GetComponent<Card>();
            _holdingCard.Mover.CanMove = false;
            _distanceToPointer = pointerPosition - (Vector2)_holdingCard.transform.position;
            Debug.Log("Card Taked");
        }
        else {
            _holdingCard = null;
        }
    }

    private void DropCard() {
        if (_holdingCard == null) { return; }

        Debug.Log("Card Dropped");
        _holdingCard.Mover.CanMove = true;
        OnCardDrop?.Invoke(_holdingCard);
        _holdingCard = null;
    }
}