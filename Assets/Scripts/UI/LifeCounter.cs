using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LifeCounter : MonoBehaviour {
    [SerializeField] private LifeView _view;

    private int _lifes = 0;

    public int Lifes => _lifes;
    public UnityAction OnLifesOver;

    private void Start() {
        _view.ChangeUI(_lifes);
    }

    public bool Initialize(int lifes) {
        if (lifes <= 0) return false;

        _lifes = lifes;
        _view.ChangeUI(_lifes);
        return true;
    }

    public bool TryToTake(int lifes) {
        if (lifes <= 0) return false;

        _lifes -= lifes;
        if (_lifes <= 0) {
            _lifes = 0;
            OnLifesOver?.Invoke();
        }
        _view.ChangeUI(_lifes);
        return true;
    }

    public bool TryToAdd(int lifes) {
        if (lifes <= 0) return false;

        _lifes += lifes;
        _view.ChangeUI(_lifes);
        return true;
    }
}
