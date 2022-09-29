using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PointerInput : IInputService, IDisposable {
    public event UnityAction<Swipe> SwipeDetected;
    public event UnityAction Pressed;
    public event UnityAction Canceled;

    private const float EPSILON = 0.1f;

    private Inputs _inputs;
    private Vector2 _lastPosition;
    private Vector2 _pressedPosition;

    public Vector2 Position => _inputs.CardDragger.Dragging.ReadValue<Vector2>();
    public Vector2 Delta => _inputs.CardDragger.Slide.ReadValue<Vector2>();

    public PointerInput() {
        _inputs = new Inputs();
        Enable();
    }

    public void Dispose() {
        Disable();
    }

    public void Enable() {
        _inputs.Enable();
        _inputs.CardDragger.TakeDrop.performed += OnPressed;
        _inputs.CardDragger.TakeDrop.canceled += OnCanceled;
    }

    public void Disable() {
        _inputs.Disable();
        _inputs.CardDragger.TakeDrop.performed -= OnPressed;
        _inputs.CardDragger.TakeDrop.canceled -= OnCanceled;
    }

    private void OnPressed(InputAction.CallbackContext ctx) {
        _pressedPosition = _lastPosition = Position;
        Pressed?.Invoke();
    }

    private void OnCanceled(InputAction.CallbackContext ctx) {
        _lastPosition = Position;
        HandleSwipe();
        Canceled?.Invoke();
    }

    private void HandleSwipe() {
        float swipeMagnitude = Mathf.Sqrt((_lastPosition - _pressedPosition).sqrMagnitude);
        if (swipeMagnitude > EPSILON) {
            Vector2 swipeDirection = (_lastPosition - _pressedPosition).normalized;
            Swipe swipe = new Swipe(swipeDirection, swipeMagnitude);
            SwipeDetected?.Invoke(swipe);
        }
    }

}
