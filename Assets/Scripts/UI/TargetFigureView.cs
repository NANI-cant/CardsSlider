using DG.Tweening;
using Unity.VectorGraphics;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(SVGImage))]
public class TargetFigureView : MonoBehaviour {
    [SerializeField] private PunchOptions _punchScale;

    private SVGImage _image;
    private FigureGenerator _generator;
    private Sequence _tweenSequence;

    [Inject]
    public void Construct(FigureGenerator generator) {
        _generator = generator;
    }

    private void Awake() => _image = GetComponent<SVGImage>();
    private void OnEnable() => _generator.OnFigureGenerated += ChangeUI;
    private void OnDisable() => _generator.OnFigureGenerated -= ChangeUI;
    private void OnDestroy() => _tweenSequence?.Kill();

    public void ChangeUI(FigureData figure) {
        _image.sprite = figure.Sprite;
        ExecuteTweening();
    }

    private void ExecuteTweening() {
        _tweenSequence?.Complete();
        _tweenSequence?.Kill();

        Color endColor = Color.white;
        Color transparentColor = endColor;
        transparentColor.a = 0f;

        _image.color = transparentColor;

        _tweenSequence.Join(_image.DOColor(endColor, 0.3f));
        _tweenSequence.Join(transform.DOPunchScale(_punchScale.Punch, _punchScale.Duration, _punchScale.Vibrato, _punchScale.Elacticity));
    }
}
