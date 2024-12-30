using UnityEngine;
using UnityEngine.AI;

public class RunMovement : IMovementStrategy
{
    public void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        agent.speed = 2f;
        agent.SetDestination(targetPosition);
    }
}