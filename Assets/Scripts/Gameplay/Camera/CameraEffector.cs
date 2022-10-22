using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraEffector : MonoBehaviour {
    [SerializeField] private Color _correct = Color.green;
    [SerializeField] private Color _wrong = Color.red;

    private Camera _camera;
    private Color _defaultColor;
    private Sequence _tweenSequence;

    private void Awake() {
        _camera = GetComponent<Camera>();
        _defaultColor = _camera.backgroundColor;
    }

    private void OnEnable() => AnswerChecker.AnswerChecked += OnAnswerChecked;
    private void OnDisable() => AnswerChecker.AnswerChecked -= OnAnswerChecked;
    private void OnDestroy() => _tweenSequence?.Kill();

    private void OnAnswerChecked(bool answerResult) {
        _tweenSequence?.Complete();
        _tweenSequence?.Kill();

        Color backColor = answerResult ? _correct : _wrong;

        _tweenSequence = DOTween.Sequence();
        _tweenSequence.Append(_camera.DOColor(backColor, 0.3f));
        _tweenSequence.Append(_camera.DOColor(_defaultColor, 0.3f));
    }
}
