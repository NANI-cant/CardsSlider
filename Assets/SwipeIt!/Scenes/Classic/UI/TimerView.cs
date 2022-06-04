using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Slider))]
public class TimerView : MonoBehaviour {
    private Slider _slider;
    private Timer _timerModel;

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

    public void ChangeUI() {
        float currentTime = _timerModel.RemaindedTime;
        float maxTime = _timerModel.SettedTime;

        _slider.maxValue = maxTime;
        _slider.value = currentTime;
    }
}
