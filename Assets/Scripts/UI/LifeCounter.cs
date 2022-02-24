using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LifeCounter : MonoBehaviour {
    public UnityAction OnLifesOver;
    public UnityAction<int> OnLifesChange;

    private int _lifes = 0;

    public int Lifes => _lifes;

    public bool Initialize(int lifes) {
        if (lifes <= 0) return false;

        _lifes = lifes;
        return true;
    }

    public bool TryToTake(int lifes) {
        if (lifes <= 0) return false;

        _lifes -= lifes;
        if (_lifes <= 0) {
            _lifes = 0;
            OnLifesOver?.Invoke();
        }
        OnLifesChange?.Invoke(Lifes);
        return true;
    }

    public bool TryToAdd(int lifes) {
        if (lifes <= 0) return false;

        _lifes += lifes;
        OnLifesChange?.Invoke(Lifes);
        return true;
    }
}
