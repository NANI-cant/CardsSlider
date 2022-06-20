using DG.Tweening;
using UnityEngine;
using Zenject;

public class SceneEntryAnimation : MonoBehaviour {
    [Header("Layouts")]
    [SerializeField] private RectTransform _targetFigure;
    [SerializeField] private RectTransform _timer;
    [SerializeField] private RectTransform _lifes;
    [SerializeField] private RectTransform _score;
    [SerializeField] private RectTransform _pauseButton;
    [SerializeField] private CanvasGroup _hud;
    [Header("Settings")]
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private float _durationAnimation;

    private CardSpawner _spawner;
    private Transform _targetCard;

    [Inject]
    public void Construct(CardSpawner spawner) {
        _spawner = spawner;
        _spawner.CardSpawned += OnCardSpawned;
    }

    private void Start() {
        MoveOnStartPosition();
        MoveOnEndPosition();
    }

    private void MoveOnStartPosition(){
        _targetFigure.localScale = _startScale;
        _timer.localScale = _startScale;
        _lifes.localScale = _startScale;
        _score.localScale = _startScale;
        _pauseButton.localScale = _startScale;
        _hud.DOFade(0, 0f);
    }

    private void MoveOnEndPosition(){
        _score.DOScale(_endScale, _durationAnimation);
        _lifes.DOScale(_endScale, _durationAnimation);
        _pauseButton.DOScale(_endScale, _durationAnimation);
        _targetFigure.DOScale(_endScale, _durationAnimation);
        _timer.DOScale(_endScale, _durationAnimation);
        _hud.DOFade(1, _durationAnimation);
    }

    private void OnCardSpawned(Card card) {
        _targetCard = card.transform;
        _targetCard.transform.localScale = _startScale;
        _targetCard.transform.DOScale(_endScale, _durationAnimation);
        _spawner.CardSpawned -= OnCardSpawned;
    }
}
