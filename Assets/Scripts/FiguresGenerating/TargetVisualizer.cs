using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TargetVisualizer : MonoBehaviour {
    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }

    public void SetImage(Sprite sprite) {
        image.sprite = sprite;
    }
}
