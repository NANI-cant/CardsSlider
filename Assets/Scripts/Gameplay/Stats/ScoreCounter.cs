using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    public event Action<int> ScoreChanged;

    private int _score = 0;

    public int Score => _score;

    public bool Add(int score) {
        if (score <= 0) return false;

        _score += score;
        ScoreChanged?.Invoke(Score);
        return true;
    }
}
