using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardSpawner : MonoBehaviour {
    [SerializeField] private Card _cardTemplate;
    [SerializeField] private Vector2 _spawnPosition;

    [Header("Debug")]
    [SerializeField] private bool _shouldLog = false;
    [SerializeField] private Color _debugColor;
    [SerializeField] private Vector2 _debugCardSize;

    public UnityAction<Card> CardSpawned;

    private Card _currentCard;

    public void Spawn(List<FigureData> figures) {
        HideOldCard();

        _currentCard = Instantiate(_cardTemplate, _spawnPosition, Quaternion.identity, transform);
        _currentCard.Initialize(figures);
        CardSpawned?.Invoke(_currentCard);

        this.Do(() => Debug.Log("Card spawned"), when: _shouldLog);
    }

    public void HideOldCard() {
        _currentCard?.Hide(false);
    }

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;
        Gizmos.DrawWireCube(_spawnPosition, _debugCardSize);
    }
}
