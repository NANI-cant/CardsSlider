using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    [SerializeField] private Card _cardTemplate;
    [SerializeField] private Vector2 _spawnPosition;

    [Header("Debug")]
    [SerializeField] private Color _debugColor;
    [SerializeField] private Vector2 _debugCardSize;

    private Card _currentCard;

    public void Spawn(List<FigureData> figures) {
        _currentCard = Instantiate(_cardTemplate, _spawnPosition, Quaternion.identity);
        _currentCard.Initialize(figures);
        Debug.Log("Card spawned");
    }

    public void DestroyCard() {
        _currentCard.Destroy();
    }

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;
        Gizmos.DrawWireCube(_spawnPosition, _debugCardSize);
    }
}
