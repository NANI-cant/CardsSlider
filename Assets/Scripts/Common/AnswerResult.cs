using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerResult {
    private Vector2 cardPosition;
    private Card card;

    public Vector2 CardPosition => cardPosition;
    public Card Card => card;

    public AnswerResult(Vector2 cardPosition, Card card) {
        this.cardPosition = cardPosition;
        this.card = card;
    }
}
