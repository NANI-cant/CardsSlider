using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class LifeCounter : MonoBehaviour {
    public UnityAction OnLifesOver;
    public UnityAction<int> OnLifesChange;

    private int _lifes;

    public int Lifes => _lifes;

    [Inject]
    public void Construct(GameplaySettings settings) {
        _lifes = settings.StartLifes;
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
