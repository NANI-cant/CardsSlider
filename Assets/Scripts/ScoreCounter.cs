using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounter : MonoBehaviour {
    private int _score = 0;
    private TextMeshProUGUI _uGUI;

    public int Score => _score;

    private void Awake() {
        ServiceLocator.RegisterService<ScoreCounter>(this);
        _uGUI = GetComponent<TextMeshProUGUI>();
        ChangeUI();
    }

    public bool Add(int score) {
        if (score <= 0) return false;

        _score += score;
        ChangeUI();
        return true;
    }

    private void ChangeUI() {
        _uGUI.text = _score.ToString();
    }
}
