using System;

public class GameRunningState : IEnterState, IExitState {
    private GameStateMachine _gameStateMachine;
    private readonly Game _game;
    private LifeCounter _lifeCounter;

    public GameRunningState(GameStateMachine gameStateMachine, Game game, LifeCounter lifeCounter) {
        _gameStateMachine = gameStateMachine;
        _game = game;
        _lifeCounter = lifeCounter;
    }

    public void Enter() {
        _lifeCounter.OnLifesOver += OnLifesOver;
        _game.OnSceneLoad?.Invoke();
    }

    public void Exit() {
        _lifeCounter.OnLifesOver -= OnLifesOver;
    }

    private void OnLifesOver() {
        _gameStateMachine.TranslateTo<GameEndingState>();
    }
}