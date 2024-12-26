using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    NavMeshAgent m_agent;
    Transform m_selfTransform;
    Transform m_target;
    CharacterType m_characterType;

    public PatrolState(NavMeshAgent agent, Transform selfTransform, CharacterType characterType)
    {
        m_agent = agent;
        m_selfTransform = selfTransform;
        m_characterType = characterType;
        m_target = GameObject.FindWithTag("Player").transform;
    }

    public override void EnterState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // 주인공의 랜덤 위치 이동
            PlayerMoveRandomly();
        }
        else if (m_characterType == CharacterType.Enemy)
        {
            // 적은 주인공 방향으로 이동
            MoveTowardsPlayer();
        }
    }

    public override void UpdateState()
    {
        if (m_characterType == CharacterType.Player)
        {
            // 목표 지점에 도달하면 다시 랜덤 위치로 이동
            if (!m_agent.pathPending && m_agent.remainingDistance <= m_agent.stoppingDistance)
            {
                PlayerMoveRandomly();
            }
        }
        else if (m_characterType == CharacterType.Enemy)
        {
            // 주인공을 향해 계속 이동
            MoveTowardsPlayer();
            Debug.Log("Patrol Patrol Patrol");
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
            m_agent.SetDestination(hit.position);
        }
    }

    void MoveTowardsPlayer()
    {
        if (m_characterType == CharacterType.Enemy && m_selfTransform != null && m_agent != null && m_agent.pathPending == false)
        {
            if (m_agent.remainingDistance <= m_agent.stoppingDistance)
            {
                // 주인공 방향으로 이동
                if (m_agent.destination != m_selfTransform.position)
                {
                    Vector3 direction = (m_target.position - m_selfTransform.position).normalized;
                    m_agent.SetDestination(m_selfTransform.position + direction * 2f);
                }
            }
        }
    }
}