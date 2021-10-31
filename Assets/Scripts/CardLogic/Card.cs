using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CardMover))]
public class Card : MonoBehaviour {
    private CardMover mover;

    public CardMover Mover => mover;

    private void Awake() {
        mover = GetComponent<CardMover>();
    }

    public void Destroy() {
        Debug.Log("Card Destroyed");
        Destroy(gameObject);
    }
}
