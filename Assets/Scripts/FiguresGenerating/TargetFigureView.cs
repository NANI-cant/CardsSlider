using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Image))]
public class TargetFigureView : MonoBehaviour {
    private Image _image;

    private FigureGenerator _generator;

    [Inject]
    public void Construct(FigureGenerator generator) {
        _generator = generator;
    }

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
