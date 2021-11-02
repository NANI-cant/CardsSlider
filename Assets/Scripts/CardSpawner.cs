using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {
    [SerializeField] private Card cardTemplate;
    [SerializeField] private Vector2 spawnPosition;

    [Header("Debug")]
    [SerializeField] private Color debugColor;
    [SerializeField] private Vector2 debugCardSize;

    public void Spawn(List<FigureData> figures) {
        Card card = Instantiate(cardTemplate, spawnPosition, Quaternion.identity);
        card.Initialize(figures);
        Debug.Log("Card spawned");
    }

    private void OnDrawGizmos() {
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(spawnPosition, debugCardSize);
    }
}
