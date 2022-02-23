using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class TargetFigureView : MonoBehaviour {
    private Image _image;

    [Inject] private FigureGenerator _generator;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    private void OnEnable() {
        _generator.OnFigureGenerated += ChangeUI;
    }

    private void OnDisable() {
        _generator.OnFigureGenerated -= ChangeUI;
    }

    public void ChangeUI(FigureData figure) {
        _image.sprite = figure.Sprite;
    }
}
