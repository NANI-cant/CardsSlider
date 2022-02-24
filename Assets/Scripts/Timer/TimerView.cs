using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerView : MonoBehaviour {
    private TextMeshProUGUI _text;

    [Inject] private Timer _timerModel;

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
