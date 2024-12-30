using UnityEngine;
using UnityEngine.AI;

public class PlayerAI : BaseAI
{
    NavMeshAgent m_agent;
    GameObject m_enemy;

    float m_attackDist = 5f;

    void ChangeToIdleState()
    {
        m_stateMachine.ChangeState(new IdleState(m_agent, transform, CharacterType.Player, m_stateMachine));
    }

    void ChangeToAttackState()
    {
        m_stateMachine.ChangeState(new AttackState(m_agent, m_enemy.transform, CharacterType.Player, m_stateMachine));
    }

    void ChangeToAvoidState()
    {
        m_stateMachine.ChangeState(new AvoidState(m_agent, m_enemy.transform, CharacterType.Player, new AvoidMovement(), m_stateMachine));
    }

    void OnDrawGizmos()
    {
        // ���� ��Ÿ�
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_attackDist);
    }

    protected override void Start()
    {
        base.Start();

        m_agent = GetComponent<NavMeshAgent>();
        m_enemy = GameObject.FindWithTag("Enemy");

        // �ʱ� ����: Idle
        ChangeToIdleState();
    }

    protected override void Update()
    {
        if (m_enemy != null)
        {
            float distanceSqr = (transform.position - m_enemy.transform.position).sqrMagnitude;
            float attackDist = m_attackDist * m_attackDist;

            if (distanceSqr < attackDist && distanceSqr > 3.5f)
            {
                // ������ �Ÿ��� ���� ���� �ȿ� ������ Attack
                Debug.Log("Player Attack Attack Attack");
                ChangeToAttackState();
            }
            else if (distanceSqr <= 3.5f)
            {
                // ���� �ʹ� ��������� Avoid
                ChangeToAvoidState();
            }
        }
        m_stateMachine.UpdateState();
    }
}