using System;
using UnityEngine.UI;

public class Game {
    public Action SceneLoaded;
    public Action GamePaused;
    public Action GameStarted;
    public Action GameOvered;
    public Action GameInterrupted;

    private GameStateMachine _gameStateMachine;

    public Game(
        LifeCounter lifeCounter,
        ScenesLoader scenesLoader,
        GameOverPanel gameOverPanel,
        GameplaySettings settings,
        PlayerProgress playerProgress,
        ScoreCounter score,
        Button continueButton,
        Button pauseButton,
        Button toMenuButton,
        IInputService input) {

        _gameStateMachine = new GameStateMachine(
            this,
            lifeCounter,
            scenesLoader,
            gameOverPanel,
            settings,
            playerProgress,
            score,
            continueButton,
            pauseButton,
            toMenuButton,
            input
        );
    }
}
