using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour {
    private TextMeshProUGUI _uGUI;

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeUI(int score) {
        _uGUI.text = score.ToString();
    }
}
