using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : BaseAI
{
    NavMeshAgent m_agent;
    GameObject m_player;
    IAttackStrategy m_attackStragety;

    float m_detectDist = 12f;
    float m_attackDist = 2f;

    void OnDrawGizmos()
    {
        // 탐지 사거리
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, m_detectDist);

        // 공격 사거리
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_attackDist);
    }

    protected override void Start()
    {
        base.Start();

        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.FindWithTag("Player");

        // 기본 공격
        m_attackStragety = new BasicAttack();

        // 초기 상태: Idle
        m_stateMachine.ChangeState(new IdleState(m_agent, transform, CharacterType.Enemy, m_stateMachine));
    }

    protected override void Update()
    {
        if (m_player != null)
        {
            Vector3 direction = m_player.transform.position - transform.position;
            float distanceSqr = direction.sqrMagnitude;

            // 주인공과의 거리가 12 이하면 Chase 상태로 전환
            if (distanceSqr < (m_detectDist * m_detectDist))
            {
                m_stateMachine.ChangeState(new ChaseState(m_agent, m_player.transform, CharacterType.Enemy, new RunMovement(), m_attackStragety, m_stateMachine));
            }
        }
        m_stateMachine.UpdateState();
    }
}