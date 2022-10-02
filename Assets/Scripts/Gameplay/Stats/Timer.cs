using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Timer : MonoBehaviour {
    private const float ACCURACITY = 0.001f;

    public event UnityAction OnTimesUp;
    public event UnityAction OnTimeChange;

    private float _settedTime;
    private Game _game;

    private float _remaindedTime;
    private bool _isRun = false;

    public float RemaindedTime => _remaindedTime;
    public float SettedTime => _settedTime;

    [Inject]
    public void Construct(Game game, GameplaySettings settings) {
        _game = game;
        _settedTime = settings.StartTime;
        _remaindedTime = _settedTime;
    }

    private void OnEnable() {
        _game.GameOvered += Stop;
        _game.GamePaused += Stop;
        _game.GameStarted += Run;
    }

    private void OnDisable() {
        _game.GameOvered -= Stop;
        _game.GamePaused -= Stop;
        _game.GameStarted -= Run;
    }

    private void Start() {
        _remaindedTime = _settedTime;
    }

    private void Update() {
        if (_isRun) {
            ExecuteRunning();
        }
    }

    public void Add(float time) {
        _settedTime += time;
        _remaindedTime += time;
        OnTimeChange?.Invoke();
    }

    public void Set(float time) {
        _settedTime = time;
        _remaindedTime = time;
        OnTimeChange?.Invoke();
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

    private void ExecuteRunning() {
        _remaindedTime -= Time.deltaTime;
        OnTimeChange?.Invoke();
        if (_remaindedTime <= ACCURACITY) {
            _remaindedTime = 0f;
            Stop();
            OnTimesUp?.Invoke();
        }
    }
}
