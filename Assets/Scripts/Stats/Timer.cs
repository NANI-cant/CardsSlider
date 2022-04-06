using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Timer : MonoBehaviour {
    public UnityAction OnTimesUp;
    public UnityAction<float> OnTimeChange;

    private float _startTime;
    private Game _game;

    private float _remaindedTime;
    private bool _isRun = false;

    public float RemaindedTime => _remaindedTime;

    [Inject]
    public void Construct(Game game, GameplaySettings settings) {
        _game = game;
        _startTime = settings.StartTime;
    }

    private void Start() {
        _remaindedTime = _startTime;
        OnTimeChange?.Invoke(RemaindedTime);
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
        OnTimeChange?.Invoke(RemaindedTime);
    }

    public void Set(float time) {
        _remaindedTime = time;
        OnTimeChange?.Invoke(RemaindedTime);
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
        OnTimeChange?.Invoke(RemaindedTime);
        if (_remaindedTime <= Constants.Epsilon) {
            _remaindedTime = 0f;
            Stop();
            OnTimesUp?.Invoke();
        }
    }
}
