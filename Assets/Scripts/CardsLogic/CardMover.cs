using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour {
    [SerializeField] private float _freeSpeed = 2f;

    private Vector2 _startPosition;
    private Transform _transform;

    public bool CanMove = true;

    private void OnValidate() {
        if (_freeSpeed < 0) _freeSpeed = 0;
    }

    private void Awake() {
        _transform = GetComponent<Transform>();
    }

    private void Start() {
        _startPosition = _transform.position;
    }

    private void FixedUpdate() {
        if (CanMove) {
            GoBack();
        }
    }

    private void GoBack() {
        float distance = Mathf.Sqrt((_startPosition - (Vector2)_transform.position).sqrMagnitude);
        if (distance <= Constants.Epsilon) {
            _transform.Translate(_startPosition - (Vector2)_transform.position);
            return;
        }

        Vector2 direction = _startPosition - (Vector2)_transform.position;
        _transform.Translate(direction * _freeSpeed * Time.deltaTime);
    }
}
