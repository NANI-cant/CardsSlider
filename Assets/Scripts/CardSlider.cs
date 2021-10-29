using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider2D))]
public class CardSlider : MonoBehaviour {
    [SerializeField] private Camera camera;
    [SerializeField] private float freeMovementSpeed = 1f;

    private bool isBlocked = false;
    private bool canSlide = false;
    private Inputs inputs;
    private Transform transform;
    private BoxCollider2D collider;
    private Vector2 startPosition;
    private Vector2 distanceToPointer;

    private Vector2 pointerPosition => camera.ScreenToWorldPoint(inputs.CardSlider.TapPosition.ReadValue<Vector2>());

    private void Awake() {
        transform = GetComponent<Transform>();
        collider = GetComponent<BoxCollider2D>();
        inputs = new Inputs();
        startPosition = transform.position;
    }

    private void OnEnable() {
        inputs.Enable();
        inputs.CardSlider.Tap.started += ctx => CanSlide(IsTapOnCard());
        inputs.CardSlider.Tap.canceled += ctx => CanSlide(false);
    }

    private void OnDisable() {
        inputs.Disable();
    }

    private void FixedUpdate() {
        if (isBlocked) {
            return;
        }
        if (canSlide) {
            MoveToPointer();
        }
        else {
            GoBack();
        }
    }

    private void GoBack() {
        Vector2 distance = startPosition - (Vector2)transform.position;
        Vector2 direction = distance.normalized;
        Vector2 distancePerFrame = Vector2.zero;
        if (Mathf.Sqrt(distance.sqrMagnitude) > freeMovementSpeed) {
            distancePerFrame = distance * Time.deltaTime;
        }
        else {
            distancePerFrame = direction * freeMovementSpeed * Time.deltaTime;
        }
        transform.Translate(distancePerFrame);
    }

    private void MoveToPointer() {
        transform.position = (Vector2)pointerPosition - distanceToPointer;
    }

    private bool IsTapOnCard() {
        Vector2 localTapPosition = transform.InverseTransformPoint(pointerPosition);
        return Mathf.Abs(localTapPosition.x) < collider.bounds.extents.x && Mathf.Abs(localTapPosition.y) < collider.bounds.extents.y;
    }

    private void CanSlide(bool value) {
        canSlide = value;
        distanceToPointer = pointerPosition - (Vector2)transform.position;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, startPosition);
    }
}