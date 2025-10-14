public class StateMachine
{
    private StateBase _currentState; // field - trường
    public StateBase CurrentState // property - thuộc tính
    {
        get => _currentState;
    }
    public void ChangeState(StateBase newState)
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