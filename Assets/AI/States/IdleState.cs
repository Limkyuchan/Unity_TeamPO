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

    public override void EnterState() { }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // ���ΰ�: ���� ��ġ �̵�
            m_stateMachine.ChangeState(new PatrolState(m_agent, m_selfTransform, CharacterType.Player, new WalkMovement()));
        }
        else if (m_characterType == CharacterType.Enemy)
        {
            // ��: ���ΰ� �������� �̵�
            m_stateMachine.ChangeState(new PatrolState(m_agent, m_selfTransform, CharacterType.Enemy, new WalkMovement()));
        }
    }

    public override void ExitState() { }
}