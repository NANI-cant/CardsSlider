using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
    [SerializeField] private float _startTime;
    [SerializeField] private TimerVizualizer _vizualizer;
    [Header("Debug")]
    [SerializeField] private float _debugRemaindedTime;

    private float _remaindedTime;
    private bool _isRun = false;

    public UnityAction OnTimesUp;

    public float RemaindedTime => _remaindedTime;

    private void Awake() {
        ServiceLocator.RegisterService<Timer>(this);
    }

    private void Start() {
        _remaindedTime = _startTime;
        _debugRemaindedTime = _remaindedTime;
        _vizualizer.Visualize(_remaindedTime);
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
            OnTimesUp?.Invoke();
        }
    }

    private void Running() {
        _remaindedTime -= Time.deltaTime;
        _vizualizer.Visualize(_remaindedTime);
        _debugRemaindedTime = _remaindedTime;
        if (_remaindedTime <= Constants.Epsilon) {
            Stop();
        }
    }
}
