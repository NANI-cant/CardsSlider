using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraEffector : MonoBehaviour {
    [SerializeField] private Color _correct = Color.green;
    [SerializeField] private Color _wrong = Color.red;

    private Camera _camera;
    private Color _defaultColor;

    private void Awake() {
        _camera = GetComponent<Camera>();
        _defaultColor = _camera.backgroundColor;
    }

    private void OnEnable() {
        AnswerChecker.AnswerChecked += OnAnswerChecked;
    }

    private void OnDisable() {
        AnswerChecker.AnswerChecked -= OnAnswerChecked;
    }

    private void OnAnswerChecked(bool answerResult) {
        Color backColor = answerResult ? _correct : _wrong;

        var sequence = DOTween.Sequence();
        sequence.Append(_camera.DOColor(backColor, 0.3f));
        sequence.Append(_camera.DOColor(_defaultColor, 0.3f));
    }
}
