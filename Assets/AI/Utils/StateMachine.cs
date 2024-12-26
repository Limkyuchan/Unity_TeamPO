public class StateMachine
{
    BaseState m_currentState;

    public void ChangeState(BaseState newState)
    {
        if (m_currentState != null)
        {
            m_currentState.ExitState();
        }

        m_currentState = newState;
        m_currentState.EnterState();
    }

    public void UpdateState()
    {
        if (m_currentState != null)
        {
            m_currentState.UpdateState();
        }
    }
}