using DG.Tweening;
using UnityEngine;

public class SceneEntryAnimation : MonoBehaviour {
    [Header("Layouts")]
    [SerializeField] private RectTransform _timer;
    [SerializeField] private RectTransform _lifes;
    [SerializeField] private RectTransform _score;
    [SerializeField] private RectTransform _pauseButton;
    [SerializeField] private CanvasGroup _hud;

    [Header("Settings")]
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private float _durationAnimation;

    private void Start() {
        Prepare();
        Execute();
    }

    private void Prepare(){
        _timer.localScale = _startScale;
        _lifes.localScale = _startScale;
        _score.localScale = _startScale;
        _pauseButton.localScale = _startScale;
        _hud.DOFade(0, 0f);
    }

    private void Execute(){
        _score.DOScale(_endScale, _durationAnimation);
        _lifes.DOScale(_endScale, _durationAnimation);
        _pauseButton.DOScale(_endScale, _durationAnimation);
        _timer.DOScale(_endScale, _durationAnimation);
        _hud.DOFade(1, _durationAnimation);
    }
}
