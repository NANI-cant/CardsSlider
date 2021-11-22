using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerResult {
    private Vector2 _cardPosition;
    private Card _card;

    public Vector2 CardPosition => _cardPosition;
    public Card Card => _card;

    public AnswerResult(Vector2 cardPosition, Card card) {
        _cardPosition = cardPosition;
        _card = card;
    }
}
