using UnityEngine;
using Zenject;

public class CardRotation : MonoBehaviour {
    [SerializeField] private Vector2 _rotatePointOffset;

    private Transform _targetCard;
    private CardSpawner _spawner;

    private Vector2 RotationPoint => transform.TransformPoint(_rotatePointOffset);

    [Inject]
    public void Construct(CardSpawner spawner) {
        _spawner = spawner;
    }

    private void OnEnable() {
        _spawner.CardSpawned += OnCardSpawned;
    }

    private void OnDisable() {
        _spawner.CardSpawned -= OnCardSpawned;
    }

    private void FixedUpdate() {
        if(_targetCard == null) return;
        
        _targetCard.rotation = RotateByPosition(_targetCard.position);
    }

    public Quaternion RotateByPosition(Vector2 position)
        => Quaternion.FromToRotation(Vector3.up, position - RotationPoint);

    private void OnCardSpawned(Card card)
        => _targetCard = card.transform;

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(RotationPoint, 0.1f);
    }
}
