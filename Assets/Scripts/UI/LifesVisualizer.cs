using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LifesVisualizer : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _text;

    public void Visualize(uint lifes) {
        _text.text = lifes.ToString();
    }
}
