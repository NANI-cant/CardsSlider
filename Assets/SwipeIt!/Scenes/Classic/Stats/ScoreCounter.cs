using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour {
    public event UnityAction<int> OnScoreChanged;

    private int _score = 0;

    public int Score => _score;

    public bool Add(int score) {
        if (score <= 0) return false;

        _score += score;
        OnScoreChanged?.Invoke(Score);
        return true;
    }
}
