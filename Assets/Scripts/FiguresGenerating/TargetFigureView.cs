using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TargetFigureView : MonoBehaviour {
    private Image _image;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    public void SetImage(Sprite sprite) {
        _image.sprite = sprite;
    }
}
