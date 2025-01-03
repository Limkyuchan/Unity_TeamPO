using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState
{
    NavMeshAgent m_agent;
    StateMachine m_stateMachine;
    Transform m_target;

    CharacterType m_characterType;
    IAttackStrategy m_attackStrategy;

    float m_attackRange = 2f;       // �� ���� ��Ÿ�

    public AttackState(NavMeshAgent agent, Transform target, CharacterType characterType, StateMachine stateMachine, IAttackStrategy attackStrategy)
    {
        m_agent = agent;
        m_target = target;
        m_characterType = characterType;
        m_stateMachine = stateMachine;
        m_attackStrategy = attackStrategy;
    }

    public override void EnterState()
    {
        if (m_characterType == CharacterType.Player)
        {
            m_attackStrategy.Attack(m_characterType, m_agent, m_target);
        }
        else if (m_characterType == CharacterType.Enemy)
        {
            float distanceSqr = (m_agent.transform.position - m_target.position).sqrMagnitude;
            float attackRangeSqr = m_attackRange * m_attackRange;

            // ���� ���� ���̸� Chase ���·� ��ȯ
            if (distanceSqr > attackRangeSqr)
            {
                m_stateMachine.ChangeState(new ChaseState(m_agent, m_target, m_characterType, new RunMovement(), m_attackStrategy, m_stateMachine));
            }
            else
            {
                m_attackStrategy.Attack(m_characterType, m_agent, m_target);
            }
        }
    }

    public override void UpdateState() { }

    public override void ExitState() { }
}