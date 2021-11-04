using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerVizualizer : MonoBehaviour {
    private TextMeshProUGUI text;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Visualize(float time) {
        text.text = time.ToString("#0.00");
    }
}
