using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    [SerializeField] private Card _cardTemplate;
    [SerializeField] private Vector2 _spawnPosition;

    [Header("Debug")]
    [SerializeField] private Color _debugColor;
    [SerializeField] private Vector2 _debugCardSize;

    public void Spawn(List<FigureData> figures) {
        Card card = Instantiate(_cardTemplate, _spawnPosition, Quaternion.identity);
        card.Initialize(figures);
        Debug.Log("Card spawned");
    }

    private void OnDrawGizmos() {
        Gizmos.color = _debugColor;
        Gizmos.DrawWireCube(_spawnPosition, _debugCardSize);
    }
}
