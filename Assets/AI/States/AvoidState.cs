using UnityEngine;
using UnityEngine.AI;

public class AvoidState : BaseState
{
    NavMeshAgent m_agent;
    StateMachine m_stateMachine;
    Transform m_target;

    CharacterType m_characterType;
    IMovementStrategy m_movementStrategy;

    float m_avoidTime = 1f;  // ȸ�� �ð�
    float m_startAvoidTime;  // ȸ�� ���� �ð�

    public AvoidState(NavMeshAgent agent, Transform target, CharacterType characterType, IMovementStrategy movementStrategy, StateMachine stateMachine)
    {
        m_agent = agent;
        m_target = target;
        m_characterType = characterType;
        m_movementStrategy = movementStrategy;
        m_stateMachine = stateMachine;
    }

    void ChangeToAttackState()
    {
        m_stateMachine.ChangeState(new AttackState(m_agent, m_target, m_characterType, m_stateMachine));
    }

    public override void EnterState()
    {
        Debug.Log("Avoid Avoid Avoid");
        m_startAvoidTime = Time.time;                           // ȸ�� ���� �ð�
        m_movementStrategy.Move(m_agent, m_target.position);    // ȸ�� ���� ����
    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // ȸ�� �ð��� ���� �� ���� ���·� ���ư����� ó��
            if (Time.time >= m_startAvoidTime + m_avoidTime)
            {
                float distanceSqr = (m_agent.transform.position - m_target.position).sqrMagnitude;

                if (distanceSqr > 4f)
                {
                    // �ٽ� ���� ���� ������ �������� ���� ���·� ���ư�
                    Debug.Log("���ΰ� Avoid --> Attack");
                    ChangeToAttackState();
                }
            }
        }
    }

    public override void ExitState()
    {
        
    }
}