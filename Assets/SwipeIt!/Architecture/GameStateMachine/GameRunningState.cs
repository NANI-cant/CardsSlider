using System;
using UnityEngine.UI;

public class GameRunningState : IEnterState, IExitState {
    private GameStateMachine _gameStateMachine;
    private Game _game;
    private LifeCounter _lifeCounter;
    private Button _pauseButton;
    private IInputService _input;

    public GameRunningState(GameStateMachine gameStateMachine, Game game, LifeCounter lifeCounter, Button pauseButton, IInputService input) {
        _gameStateMachine = gameStateMachine;
        _game = game;
        _lifeCounter = lifeCounter;
        _pauseButton = pauseButton;
        _input = input;
    }

    public void Enter() {
        _input.Enable();
        _pauseButton.onClick.AddListener(_gameStateMachine.TranslateTo<GamePauseState>);
        _lifeCounter.OnLifesOver += OnLifesOver;
        _game.SceneLoaded?.Invoke();
    }

    public void Exit() {
        _pauseButton.onClick.RemoveListener(_gameStateMachine.TranslateTo<GamePauseState>);
        _lifeCounter.OnLifesOver -= OnLifesOver;
    }

    private void OnLifesOver() {
        _gameStateMachine.TranslateTo<GameEndState>();
    }
}