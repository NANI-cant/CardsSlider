using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour {
    private TextMeshProUGUI _uGUI;

    [Inject] private ScoreCounter _scoreModel;

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        _scoreModel.OnScoreChanged += ChangeUI;
    }

    private void OnDisable() {
        _scoreModel.OnScoreChanged -= ChangeUI;
    }

    private void Start() {
        ChangeUI(_scoreModel.Score);
    }

    private void ChangeUI(int score) {
        _uGUI.text = score.ToString();
    }
}
