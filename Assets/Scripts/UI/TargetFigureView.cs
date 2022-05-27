using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(SVGImage))]
public class TargetFigureView : MonoBehaviour {
    private SVGImage _image;

    private FigureGenerator _generator;

    [Inject]
    public void Construct(FigureGenerator generator) {
        _generator = generator;
    }

    private void Awake() {
        _image = GetComponent<SVGImage>();
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
