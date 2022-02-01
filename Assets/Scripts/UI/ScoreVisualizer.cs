using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreVisualizer : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _text;

    public void Visualize(uint score) {
        _text.text = score.ToString();
    }
}
