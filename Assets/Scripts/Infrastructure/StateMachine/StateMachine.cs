using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : IStateMachine {
    protected Dictionary<Type, IState> _states;
    protected IState _activeState;

    public void Enter<TState>() where TState : class, IState {
        ChangeState<TState>().Enter();
    }

    public IState GetActiveState() {
        return _activeState;
    }

    private TState ChangeState<TState>() where TState : class, IState {
        _activeState?.Exit();

        TState state = GetState<TState>();
        _activeState = state;

        return state;
    }

    private TState GetState<TState>() where TState : class, IState {
        return _states[typeof(TState)] as TState;
    }
}