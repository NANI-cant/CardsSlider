using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CardMover))]
[RequireComponent(typeof(CardVisualizator))]
public class Card : MonoBehaviour {
    private List<FigureData> figures;
    
    private CardMover mover;
    private CardVisualizator visualizator;

    public CardMover Mover => mover;
    public CardVisualizator Visualizator => visualizator;

    private void Awake() {
        mover = GetComponent<CardMover>();
        visualizator = GetComponent<CardVisualizator>();
    }

    public void Destroy() {
        Debug.Log("Card Destroyed");
        Destroy(gameObject);
    }
}
