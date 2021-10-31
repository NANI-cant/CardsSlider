using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour {
    [SerializeField] private float freeSpeed = 2f;

    private Vector2 startPosition;
    private Transform transform;

    public bool CanMove = true;

    private void Awake() {
        transform = GetComponent<Transform>();
    }

    private void Start() {
        startPosition = transform.position;
    }

    private void FixedUpdate() {
        if (CanMove) {
            GoBack();
        }
    }

    private void GoBack() {
        float distance = Mathf.Sqrt((startPosition - (Vector2)transform.position).sqrMagnitude);
        if (distance <= Constants.epsilon) { return; }

        Vector2 direction = startPosition - (Vector2)transform.position;
        transform.Translate(direction * freeSpeed * Time.deltaTime);
    }
}
