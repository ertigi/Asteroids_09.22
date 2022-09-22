public class UpdateStateMachine : StateMachine {
    public virtual void UpdateState() {
        if (_activeState is IUpdateState updateState)
            updateState.GameUpdate();
    }

    public virtual void FixedUpdateState() {
        if (_activeState is IFixedUpdateState fixedUpdateState)
            fixedUpdateState.GameFixedUpdate();
    }

    public virtual void LateUpdateState() {
        if (_activeState is ILateUpdateState lateUpdateState)
            lateUpdateState.GameLateUpdate();
    }
}