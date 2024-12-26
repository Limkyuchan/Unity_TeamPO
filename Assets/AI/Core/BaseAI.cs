using UnityEngine;

public abstract class BaseAI : MonoBehaviour
{
    protected StateMachine m_stateMachine;

    protected virtual void Start()
    {
        m_stateMachine = new StateMachine();
    }

    protected virtual void Update()
    {
        m_stateMachine.UpdateState();
    }
}