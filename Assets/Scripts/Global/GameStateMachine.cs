using System;
using System.Collections.Generic;

public class GameStateMachine : IStateMachine {
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public GameStateMachine(Game game, LifeCounter lifeCounter, ScenesLoader scenesLoader, GameOverPanel gameOverPanel) {
        _states = new Dictionary<Type, IState> {
            [typeof(GameRunningState)] = new GameRunningState(this, game, lifeCounter),
            [typeof(GameEndingState)] = new GameEndingState(this, game, scenesLoader, gameOverPanel),
        };
        TranslateTo<GameRunningState>();
    }

    public void TranslateTo<StateType>() {
        _activeState?.Do(() => ((IExitState)_activeState).Exit(), _activeState is IExitState);
        _activeState = _states[typeof(StateType)];
        _activeState?.Do(() => ((IEnterState)_activeState).Enter(), _activeState is IEnterState);
    }
}
