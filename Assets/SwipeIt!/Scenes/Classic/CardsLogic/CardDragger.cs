using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class CardDragger : MonoBehaviour {
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _whatIsCard;
    [SerializeField] private CardRailways _railways;
    [SerializeField] private bool _shouldLog;

    private Game _game;

    private Card _holdingCard;
    private IInputService _input;
    private Vector2 _distanceToPointer;

    public event UnityAction<Card> OnCardDrop;

    private Vector2 _pointerPosition => _camera.ScreenToWorldPoint(_input.Position);

    [Inject]
    public void Construct(Game game, IInputService input) {
        _game = game;
        _input = input;
    }

    private void OnEnable() {
        _input.Pressed += TakeCard;
        _input.Canceled += DropCard;
    }

    private void OnDisable() {
        _input.Pressed -= TakeCard;
        _input.Canceled -= DropCard;
    }

    private void FixedUpdate() {
        DragCard();
    }

    private void DragCard() {
        if (_holdingCard == null) return;

        _holdingCard.transform.position = _railways.TranslateByDistance(_pointerPosition.x - _distanceToPointer.x);
    }

    private void TakeCard() {
        RaycastHit2D hitResult = Physics2D.Raycast(_pointerPosition, Vector2.zero, float.MaxValue, _whatIsCard);
        if (hitResult.collider != null) {
            _holdingCard = hitResult.collider.GetComponent<Card>();
            _holdingCard.Mover.CanMove = false;
            _distanceToPointer = _pointerPosition - (Vector2)_holdingCard.transform.position;

            this.Do(() => Debug.Log("Card Taked"), when: _shouldLog);
        }
        else {
            _holdingCard = null;
        }
    }

    private void DropCard() {
        if (_holdingCard == null) { return; }

        this.Do(() => Debug.Log("Card Dropped"), when: _shouldLog);
        _holdingCard.Mover.CanMove = true;
        OnCardDrop?.Invoke(_holdingCard);
        _holdingCard = null;
    }
}