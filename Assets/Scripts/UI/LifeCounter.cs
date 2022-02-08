using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LifeCounter : MonoBehaviour {
    private int _lifes = 0;
    private TextMeshProUGUI _uGUI;

    public int Lifes => _lifes;
    public UnityAction OnLifesOver;

    private void Awake() {
        _uGUI = GetComponent<TextMeshProUGUI>();
        ChangeUI();
    }

    public bool Initialize(int lifes) {
        if (lifes <= 0) return false;

        _lifes = lifes;
        ChangeUI();
        return true;
    }

    public bool Take(int lifes) {
        if (lifes <= 0) return false;

        _lifes -= lifes;
        if (_lifes <= 0) {
            _lifes = 0;
            OnLifesOver?.Invoke();
        }
        ChangeUI();
        return true;
    }

    public bool Add(int lifes) {
        if (lifes <= 0) return false;

        _lifes += lifes;
        ChangeUI();
        return true;
    }

    private void ChangeUI() {
        _uGUI.text = _lifes.ToString();
    }
}
