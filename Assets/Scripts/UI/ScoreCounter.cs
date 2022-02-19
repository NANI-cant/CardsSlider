using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    [SerializeField] private ScoreView _view;

    private int _score = 0;

    public int Score => _score;

    private void Start() {
        _view.ChangeUI(_score);
    }

    public bool Add(int score) {
        if (score <= 0) return false;

        _score += score;
        _view.ChangeUI(_score);
        return true;
    }
}
