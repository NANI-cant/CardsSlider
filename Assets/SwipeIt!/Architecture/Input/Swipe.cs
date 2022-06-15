using UnityEngine;

public struct Swipe {
    private Vector2 _direction;
    private float _magnitude;

    public Vector2 Direction => _direction;
    public float Magnitude => _magnitude;

    public Swipe(Vector2 direction, float magnitude) {
        _direction = direction;
        _magnitude = magnitude;
    }
}
