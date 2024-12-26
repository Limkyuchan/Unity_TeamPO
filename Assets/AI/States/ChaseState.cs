using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    NavMeshAgent m_agent;
    Transform m_target;
    CharacterType m_characterType;

    public ChaseState(NavMeshAgent agent, Transform target, CharacterType characterType)
    {
        m_agent = agent;
        m_target = target;
        m_characterType = characterType;
    }

    public override void EnterState()
    {
       
    }

    public override void UpdateState()
    {
        if (m_target != null)
        {
            m_agent.SetDestination(m_target.position);
        }
        
        if (m_characterType == CharacterType.Enemy)
        {
            Debug.Log("Chase Chase Chase");
        }
    }

    public override void ExitState()
    {
       
    }
}