using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour {
    [SerializeField] private Game _game;
    [SerializeField] private UnityEvent _onSceneStart;
    [SerializeField] private UnityEvent _onGameStart;
    [SerializeField] private UnityEvent _onGameOver;

    private UnityAction _sceneStartInvoke;
    private UnityAction _gameStartInvoke;
    private UnityAction _gameOverInvoke;

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
