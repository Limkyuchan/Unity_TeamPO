using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : BaseAI
{
    NavMeshAgent m_agent;
    GameObject m_enemy;

    protected override void Start()
    {
        base.Start();

        m_agent = GetComponent<NavMeshAgent>();
        m_enemy = GameObject.FindWithTag("Enemy");

        // 초기 상태: Idle
        m_stateMachine.ChangeState(new IdleState(m_agent, transform, CharacterType.Player, m_stateMachine));
    }

    protected override void Update()
    {
        base.Update();

        if (m_enemy != null)
        {
            float distance = Vector3.Distance(transform.position, m_enemy.transform.position);

            // 적과의 거리가 10 이하면 Chase 상태로 전환
            if (distance < 10f)
            {
                m_stateMachine.ChangeState(new ChaseState(m_agent, m_enemy.transform, CharacterType.Player));
            }
        }

        m_stateMachine.UpdateState();
    }
}