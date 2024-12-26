using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    NavMeshAgent m_agent;
    StateMachine m_stateMachine;
    Transform m_selfTransform;
    CharacterType m_characterType;

    public IdleState(NavMeshAgent agent, Transform selfTransform, CharacterType characterType, StateMachine stateMachine)
    {
        m_agent = agent;
        m_selfTransform = selfTransform;
        m_characterType = characterType;
        m_stateMachine = stateMachine;
    }

    public override void EnterState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // 랜덤 위치 이동: Patrol 상태로 전환
            m_stateMachine.ChangeState(new PatrolState(m_agent, m_selfTransform, CharacterType.Player));
        }
        else if (m_characterType == CharacterType.Enemy)    // 적: 주인공 방향으로 이동
        {
            m_stateMachine.ChangeState(new PatrolState(m_agent, m_selfTransform, CharacterType.Enemy));
        }
    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Enemy)
        {
            Debug.Log("Idle Idle Idle");
        }
    }

    public override void ExitState()
    {
       
    }
}