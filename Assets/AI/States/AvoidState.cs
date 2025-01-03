using UnityEngine;
using UnityEngine.AI;

public class AvoidState : BaseState
{
    NavMeshAgent m_agent;
    StateMachine m_stateMachine;
    Transform m_target;

    CharacterType m_characterType;
    IMovementStrategy m_movementStrategy;
    IAttackStrategy m_attackStrategy;

    float m_attackDist = 2f;
    float m_avoidTime = 1f;  // 회피 시간
    float m_startAvoidTime;  // 회피 시작 시간

    public AvoidState(NavMeshAgent agent, Transform target, CharacterType characterType, IMovementStrategy movementStrategy, IAttackStrategy attackStrategy, StateMachine stateMachine)
    {
        m_agent = agent;
        m_target = target;
        m_characterType = characterType;
        m_movementStrategy = movementStrategy;
        m_attackStrategy = attackStrategy;
        m_stateMachine = stateMachine;
    }

    public override void EnterState()
    {
        m_startAvoidTime = Time.time;                           // 회피 시작 시간
        m_movementStrategy.Move(m_agent, m_target.position);    // 회피 동작 실행
    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // 회피 시간이 지난 후 공격 상태로 돌아가도록 처리
            if (Time.time >= m_startAvoidTime + m_avoidTime)
            {
                float distanceSqr = (m_agent.transform.position - m_target.position).sqrMagnitude;

                if (distanceSqr > (m_attackDist * m_attackDist))
                {
                    // 다시 공격 범위 안으로 들어왔으면 공격 상태로 돌아감
                    ChangeToAttackState();
                }
            }
        }
    }

    public override void ExitState() { }

    void ChangeToAttackState()
    {
        m_stateMachine.ChangeState(new AttackState(m_agent, m_target, m_characterType, m_stateMachine, m_attackStrategy));
    }
}