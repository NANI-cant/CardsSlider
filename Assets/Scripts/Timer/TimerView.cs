using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerView : MonoBehaviour {
    private TextMeshProUGUI _text;

    private Timer _timerModel;

    [Inject]
    public void Construct(Timer timer) {
        _timerModel = timer;
    }

    private void Awake() {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        _timerModel.OnTimeChange += ChangeUI;
    }

    private void OnDisable() {
        _timerModel.OnTimeChange -= ChangeUI;
    }

    public void ChangeUI(float time) {
        _text.text = time.ToString("#0.00");
    }
}
