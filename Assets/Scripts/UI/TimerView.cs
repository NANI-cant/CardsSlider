using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class TimerView : MonoBehaviour {
    [SerializeField][Range(0, 1)] private float _startShakingValue = 0.3f;
    [SerializeField] private ShakeOptions _shakeOptions;

    private Slider _slider;
    private Timer _timerModel;
    private Tweener _shaking;

    [Inject]
    public void Construct(Timer timer) {
        _timerModel = timer;
    }

    private void Awake() => _slider = GetComponent<Slider>();
    private void OnEnable() => _timerModel.OnTimeChange += ChangeUI;
    private void OnDisable() => _timerModel.OnTimeChange -= ChangeUI;
    private void Start() => ChangeUI();
    private void OnDestroy() => _shaking?.Kill();

    private void ChangeUI() {
        float currentTime = _timerModel.RemaindedTime;
        float maxTime = _timerModel.SettedTime;

        _slider.maxValue = maxTime;
        _slider.value = currentTime;

        HandleTweening();
    }

    private void HandleTweening() {
        if (_slider.value / _slider.maxValue > _startShakingValue) {
            _shaking?.Complete();
            _shaking?.Kill();
            return;
        }

        if (_shaking == null || !_shaking.active) {
            _shaking = transform.DOShakePosition(_shakeOptions.Duration, _shakeOptions.Strength, _shakeOptions.Vibrato, _shakeOptions.Randomness, false, _shakeOptions.FadeOut);
            return;
        }
    }
}
