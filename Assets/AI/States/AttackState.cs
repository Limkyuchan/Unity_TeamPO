using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState
{
    NavMeshAgent m_agent;
    StateMachine m_stateMachine;
    Transform m_target;

    CharacterType m_characterType;

    float m_attackRange = 2f;       // 적 공격 사거리

    public AttackState(NavMeshAgent agent, Transform target, CharacterType characterType, StateMachine stateMachine)
    {
        m_agent = agent;
        m_target = target;
        m_characterType = characterType;
        m_stateMachine = stateMachine;
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Enemy)
        {
            float distanceSqr = (m_agent.transform.position - m_target.position).sqrMagnitude;
            float attackRangeSqr = m_attackRange * m_attackRange;

            // 공격 범위 밖이면 Chase 상태로 전환
            if (distanceSqr > attackRangeSqr)
            {
                m_stateMachine.ChangeState(new ChaseState(m_agent, m_target, m_characterType, new RunMovement(), m_stateMachine));
            }
            else
            {
                Debug.Log("Enemy Attack Attack Attack");
            }
        }
    }

    public override void ExitState()
    {
        
    }
}