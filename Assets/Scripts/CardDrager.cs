using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CardDrager : MonoBehaviour {
    [SerializeField] Camera camera;
    [SerializeField] private float freeMovementSpeed = 1f;
    [Header("Debug")]
    [SerializeField] private Color debugColor;

    private Card card;

    private bool canDrag = false;
    private Inputs inputs;
    private Vector2 startPosition;
    private Vector2 distanceToPointer;
    private UnityAction<AnswerResult> OnStopSliding;

    private Vector2 pointerPosition => camera.ScreenToWorldPoint(inputs.CardSlider.TapPosition.ReadValue<Vector2>());

    private void Awake() {
        transform = GetComponent<Transform>();
        collider = GetComponent<BoxCollider2D>();
        card = GetComponent<Card>();
        inputs = new Inputs();
        startPosition = transform.position;
    }


    private void OnEnable() {
        inputs.Enable();
        inputs.CardSlider.Tap.started += ctx => StartSliding(IsTapOnCard());
        inputs.CardSlider.Tap.canceled += ctx => StopSliding();
    }

    private void OnDisable() {
        inputs.Disable();
    }

    private void FixedUpdate() {
        if (isBlocked) { return; }

        if (canDrag) {
            MoveToPointer();
        }
        else {
            GoBack();
        }
    }

    public void Initialize(Camera camera, AnswerChecker yesCheck, AnswerChecker noCheck) {
        this.camera = camera;
        OnStopSliding += yesCheck.Check;
        OnStopSliding += noCheck.Check;
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
        return Mathf.Abs(localTapPosition.x) < GetComponent<Collider>().bounds.extents.x && Mathf.Abs(localTapPosition.y) < GetComponent<Collider>().bounds.extents.y;
    }

    private void StartSliding(bool isTapOnCard) {
        if (!isTapOnCard) {
            return;
        }

        Debug.Log("Start Sliding");
        canDrag = true;
        distanceToPointer = pointerPosition - (Vector2)transform.position;
    }

    private void StopSliding() {
        Debug.Log("Stop Sliding");
        canDrag = false;
        AnswerResult result = new AnswerResult(transform.position, card);
        OnStopSliding?.Invoke(result);
    }

    private void OnDrawGizmos() {
        Gizmos.color = debugColor;
        Gizmos.DrawLine(transform.position, startPosition);
    }
}