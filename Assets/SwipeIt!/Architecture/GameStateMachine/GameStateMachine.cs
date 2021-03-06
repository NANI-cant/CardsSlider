using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameStateMachine : IStateMachine {
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine(
        Game game,
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
        _states = new Dictionary<Type, IState> {
            [typeof(GameRunningState)] = new GameRunningState(this, game, lifeCounter, pauseButton, input),
            [typeof(GameEndState)] = new GameEndState(this, game, scenesLoader, gameOverPanel, settings, playerProgress, score, input),
            [typeof(GamePauseState)] = new GamePauseState(this, game, scenesLoader, continueButton, toMenuButton, input),
        };
        TranslateTo<GameRunningState>();
    }

    public void TranslateTo<StateType>() {
        _activeState?.Do(() => ((IExitState)_activeState).Exit(), _activeState is IExitState);
        _activeState = _states[typeof(StateType)];
        _activeState?.Do(() => ((IEnterState)_activeState).Enter(), _activeState is IEnterState);
    }
}
