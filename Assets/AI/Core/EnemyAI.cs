using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    ICharacterAI m_currentState;
    IMovementStrategy m_movementStrategy;
    IAttackStrategy m_attackStrategy;

    public void ChangeState(ICharacterAI newState)
    {
        if (m_currentState != null)
        {
            m_currentState.ExitState();
        }

        m_currentState = newState;
        m_currentState.EnterState();
    }

    public bool FindPlayer()
    {
        // 플레이어 탐지 로직
        //return Vector3.Distance(transform.position, Player.Instance.transform.position) < 10f;
        return true;
    }

    void Start()
    {
        ChangeState(new IdleState());
    }

    void Update()
    {
        if (m_currentState != null)
        {
            
        }
    }
}