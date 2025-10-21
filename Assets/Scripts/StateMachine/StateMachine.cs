public class StateMachine
{
    private AgentStateBase _currentState; // field - trường
    public AgentStateBase CurrentState // property - thuộc tính
    {
        get => _currentState;
    }
    public void ChangeState(AgentStateBase newState)
    {
        // null check
        if (newState == null)
        {
            return;
        }

        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}