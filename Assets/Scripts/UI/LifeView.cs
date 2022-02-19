using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LifeView : MonoBehaviour {
    private TextMeshProUGUI _uGUI;

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeUI(int lifes) {
        _uGUI.text = lifes.ToString();
    }
}
