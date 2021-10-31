using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Card : MonoBehaviour {
    public void Destroy() {
        Debug.Log("Card Destroyed");
        Destroy(gameObject);
    }
}
