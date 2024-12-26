using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : BaseAI
{
    NavMeshAgent m_agent;
    GameObject m_player;

    protected override void Start()
    {
        base.Start();

        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.FindWithTag("Player");

        // 초기 상태: Idle
        m_stateMachine.ChangeState(new IdleState(m_agent, transform, CharacterType.Enemy, m_stateMachine));
    }

    protected override void Update()
    {
        if (m_player != null)
        {
            float distance = Vector3.Distance(transform.position, m_player.transform.position);

            // 주인공과의 거리가 10 이하면 Chase 상태로 전환
            if (distance < 10f)
            {
                m_stateMachine.ChangeState(new ChaseState(m_agent, m_player.transform, CharacterType.Enemy));
            }
        }

        m_stateMachine.UpdateState();
    }
}