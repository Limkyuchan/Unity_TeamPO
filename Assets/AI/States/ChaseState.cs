using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    NavMeshAgent m_agent;
    StateMachine m_stateMachine;
    Transform m_target;

    CharacterType m_characterType;
    IMovementStrategy m_movementStrategy;

    float m_attackRange = 2f;       // 적 공격 사거리

    public ChaseState(NavMeshAgent agent, Transform target, CharacterType characterType, IMovementStrategy movementStrategy, StateMachine stateMachine)
    {
        m_agent = agent;
        m_target = target;
        m_characterType = characterType;
        m_stateMachine = stateMachine;
        m_movementStrategy = movementStrategy;
    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Enemy)
        {
            if (m_target != null)
            {
                Debug.Log("Chase Chase Chase");
                m_movementStrategy.Move(m_agent, m_target.position);

                float distanceSqr = (m_agent.transform.position - m_target.position).sqrMagnitude;
                float attackRangeSqr = m_attackRange * m_attackRange;

                if (distanceSqr <= attackRangeSqr)      // 공격 범위에 들어오면 상태 전환
                {
                    Debug.Log("Chase -> Attack 전환, m_characterType: " + m_characterType);
                    m_stateMachine.ChangeState(new AttackState(m_agent, m_target, m_characterType, m_stateMachine));
                }
            }
        }
    }

    public override void ExitState()
    {

    }
}