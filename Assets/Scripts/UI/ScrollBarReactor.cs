using UnityEngine;

public class ScrollBarReactor : MonoBehaviour {
    [SerializeField] private float _speed;

    private Vector2 _startPosition;

    private void Awake() {
        _startPosition = transform.position;
    }

    public void React(float value) {
        transform.position = _startPosition + new Vector2(_speed * value, 0);
    }
}
