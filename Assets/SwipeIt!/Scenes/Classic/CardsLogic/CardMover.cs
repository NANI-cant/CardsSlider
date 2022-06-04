using UnityEngine;

public class CardMover : MonoBehaviour {
    [Min(0)][SerializeField] private float _freeSpeed = 2f;

    private const float ACCURACITY = 0.001f;

    private Vector2 _startPosition;
    private Transform _transform;

    public bool CanMove = true;

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
        if (distance <= ACCURACITY) {
            _transform.Translate(_startPosition - (Vector2)_transform.position);
            return;
        }

        Vector2 direction = _startPosition - (Vector2)_transform.position;
        _transform.Translate(direction * _freeSpeed * Time.deltaTime);
    }
}
