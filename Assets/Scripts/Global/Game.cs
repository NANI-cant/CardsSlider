using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Game : MonoBehaviour {
    public UnityAction OnSceneStart;
    public UnityAction OnGameStart;
    public UnityAction OnGameOver;

    private LifeCounter _life;

    [Inject]
    public void Construct(LifeCounter lifeCounter) {
        _life = lifeCounter;
    }

    private void OnEnable() {
        _life.OnLifesOver += OnPlayerLifesOver;
    }

    private void OnDisable() {
        _life.OnLifesOver -= OnPlayerLifesOver;
    }

    private void Start() {
        OnSceneStart?.Invoke();
    }

    private void OnPlayerLifesOver() {
        OnGameOver?.Invoke();
    }
}
