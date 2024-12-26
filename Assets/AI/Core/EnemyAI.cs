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

        // �ʱ� ����: Idle
        m_stateMachine.ChangeState(new IdleState(m_agent, transform, CharacterType.Enemy, m_stateMachine));
    }

    protected override void Update()
    {
        if (m_player != null)
        {
            float distance = Vector3.Distance(transform.position, m_player.transform.position);

            // ���ΰ����� �Ÿ��� 10 ���ϸ� Chase ���·� ��ȯ
            if (distance < 10f)
            {
                m_stateMachine.ChangeState(new ChaseState(m_agent, m_player.transform, CharacterType.Enemy));
            }
        }

        m_stateMachine.UpdateState();
    }
}