using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    NavMeshAgent m_agent;
    Transform m_selfTransform;
    Transform m_target;

    CharacterType m_characterType;
    IMovementStrategy m_movementStrategy;

    public PatrolState(NavMeshAgent agent, Transform selfTransform, CharacterType characterType, IMovementStrategy movementStrategy)
    {
        m_agent = agent;
        m_selfTransform = selfTransform;
        m_characterType = characterType;
        m_movementStrategy = movementStrategy;
        m_target = GameObject.FindWithTag("Player").transform;
    }

    public override void EnterState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // ���ΰ��� ���� ��ġ �̵�
            PlayerMoveRandomly();
        }
        else if (m_characterType == CharacterType.Enemy)
        {
            // ���� ���ΰ� �������� �̵�
            MoveToPlayer();
        }
    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // ��ǥ ������ �����ϸ� �ٽ� ���� ��ġ�� �̵�
            if (!m_agent.pathPending && m_agent.remainingDistance <= m_agent.stoppingDistance)
            {
                PlayerMoveRandomly();
            }
        }
        else if (m_characterType == CharacterType.Enemy)
        {
            // ���ΰ��� ���� ��� �̵�
            MoveToPlayer();
        }
    }

    public override void ExitState()
    {

    }

    void PlayerMoveRandomly()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 5f + m_selfTransform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, 5f, NavMesh.AllAreas))
        {
            m_movementStrategy.Move(m_agent, hit.position);
        }
    }

    void MoveToPlayer()
    {
        if (m_characterType == CharacterType.Enemy && m_selfTransform != null && m_agent != null && m_agent.pathPending == false)
        {
            if (m_agent.remainingDistance <= m_agent.stoppingDistance)
            {
                // ���ΰ� �������� �̵�
                if (m_agent.destination != m_selfTransform.position)
                {
                    Vector3 direction = (m_target.position - m_selfTransform.position).normalized;
                    Vector3 targetPosition = m_selfTransform.position + direction * 2f;

                    m_movementStrategy.Move(m_agent, targetPosition);
                }
            }
        }
    }
}