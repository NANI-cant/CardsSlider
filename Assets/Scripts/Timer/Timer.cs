using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    [SerializeField] private float _startTime;
    [SerializeField] private TimerView _view;
    [SerializeField] private Game _game;
    [Header("Debug")]
    [SerializeField] private float _debugRemaindedTime;

    private float _remaindedTime;
    private bool _isRun = false;

    public UnityAction OnTimesUp;

    public float RemaindedTime => _remaindedTime;

    private void OnValidate() {
        if (_startTime < 0) _startTime = 0;
    }

    private void Start() {
        _remaindedTime = _startTime;
        _debugRemaindedTime = _remaindedTime;
        _view.Visualize(_remaindedTime);
    }

    private void OnEnable() {
        _game.OnGameOver += Stop;
    }

    private void OnDisable() {
        _game.OnGameOver -= Stop;
    }

    private void Update() {
        if (_isRun) {
            Running();
        }
    }

    public void Add(float time) {
        _remaindedTime += time;
        _debugRemaindedTime = _remaindedTime;
    }

    public void Set(float time) {
        _remaindedTime = time;
        _debugRemaindedTime = _remaindedTime;
    }

    [ContextMenu("Run")]
    public void Run() {
        if (!_isRun) {
            _isRun = true;
        }
    }

    [ContextMenu("Stop")]
    private void Stop() {
        if (_isRun) {
            _isRun = false;
        }
    }

    private void Running() {
        _remaindedTime -= Time.deltaTime;
        _debugRemaindedTime = _remaindedTime;
        if (_remaindedTime <= Constants.Epsilon) {
            _remaindedTime = 0f;
            Stop();
            OnTimesUp?.Invoke();
        }
        _view.Visualize(_remaindedTime);
    }
}
