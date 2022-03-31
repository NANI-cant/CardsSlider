using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class UIEvents : MonoBehaviour {
    [SerializeField] private UnityEvent _onSceneStart;
    [SerializeField] private UnityEvent _onGameStart;
    [SerializeField] private UnityEvent _onGameOver;

    private Game _game;

    private UnityAction _sceneStartInvoke;
    private UnityAction _gameStartInvoke;
    private UnityAction _gameOverInvoke;

    [Inject]
    public void Construct(Game game) {
        _game = game;
    }

    private void OnEnable() {
        _sceneStartInvoke = () => _onSceneStart?.Invoke();
        _gameStartInvoke = () => _onGameStart?.Invoke();
        _gameOverInvoke = () => _onGameOver?.Invoke();

        _game.OnSceneStart += _sceneStartInvoke;
        _game.OnGameStart += _gameStartInvoke;
        _game.OnGameOver += _gameOverInvoke;
    }

    private void OnDisable() {
        _game.OnSceneStart -= _sceneStartInvoke;
        _game.OnGameStart -= _gameStartInvoke;
        _game.OnGameOver -= _gameOverInvoke;
    }
}
