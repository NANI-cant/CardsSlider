using UnityEngine.Events;

public class Game {
    public UnityAction OnSceneLoad;
    public UnityAction OnGameStart;
    public UnityAction OnGameOver;

    private LifeCounter _life;
    private GameStateMachine _gameStateMachine;

    public Game(LifeCounter lifeCounter, ScenesLoader scenesLoader, GameOverPanel gameOverPanel) {
        _life = lifeCounter;
        _gameStateMachine = new GameStateMachine(this, _life, scenesLoader, gameOverPanel);
    }
}
