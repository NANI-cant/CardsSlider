using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class TimerView : MonoBehaviour {
    [SerializeField] private ShakeOptions _shakeOptions;

    private Slider _slider;
    private Timer _timerModel;
    private Tweener _shaking;

    [Inject]
    public void Construct(Timer timer) {
        _timerModel = timer;
    }

    private void Awake() {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable() {
        _timerModel.OnTimeChange += ChangeUI;
    }

    private void OnDisable() {
        _timerModel.OnTimeChange -= ChangeUI;
    }

    private void Start() {
        ChangeUI();
    }

    private void ChangeUI() {
        float currentTime = _timerModel.RemaindedTime;
        float maxTime = _timerModel.SettedTime;

        _slider.maxValue = maxTime;
        _slider.value = currentTime;

        HandleTweening();
    }

    private void HandleTweening() {
        if (_slider.value / _slider.maxValue > 0.5f) {
            _shaking?.Complete();
        }
        else if (_shaking == null || !_shaking.active) {
            _shaking = transform.DOShakePosition(_shakeOptions.Duration, _shakeOptions.Strength, _shakeOptions.Vibrato, _shakeOptions.Randomness, false, _shakeOptions.FadeOut);
        }
    }
}
