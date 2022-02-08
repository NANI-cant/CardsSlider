using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CardDragger : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _whatIsCard;
    [SerializeField] private Game _game;

    private Card _holdingCard;
    private Inputs _inputs;
    private Vector2 _distanceToPointer;
    private bool _canDrag = true;

    public UnityAction<Card> OnCardDrop;

    private Vector2 _pointerPosition => _camera.ScreenToWorldPoint(_inputs.CardDragger.Dragging.ReadValue<Vector2>());

    private void Awake() {
        _inputs = new Inputs();
    }

    private void OnEnable() {
        _inputs.Enable();
        _inputs.CardDragger.TakeDrop.started += ctx => TakeCard();
        _inputs.CardDragger.TakeDrop.canceled += ctx => DropCard();
        _game.OnGameOver += ForbidDragging;
        _game.OnSceneStart += AllowDragging;
    }

    private void OnDisable() {
        _inputs.Disable();
        _game.OnGameOver -= ForbidDragging;
        _game.OnSceneStart -= AllowDragging;
    }

    private void FixedUpdate() {
        DragCard();
    }

    private void DragCard() {
        if (!_canDrag) return;
        if (_holdingCard == null) return;

        _holdingCard.transform.position = _pointerPosition - _distanceToPointer;
    }

    private void TakeCard() {
        RaycastHit2D hitResult = Physics2D.Raycast(_pointerPosition, Vector2.zero, float.MaxValue, _whatIsCard);
        if (hitResult.collider != null) {
            _holdingCard = hitResult.collider.GetComponent<Card>();
            _holdingCard.Mover.CanMove = false;
            _distanceToPointer = _pointerPosition - (Vector2)_holdingCard.transform.position;
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

    private void ForbidDragging() => _canDrag = false;
    private void AllowDragging() => _canDrag = true;
}