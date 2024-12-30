using UnityEngine;
using UnityEngine.AI;

public class WalkMovement : IMovementStrategy
{
    public void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        agent.speed = 1.5f;
        agent.SetDestination(targetPosition);
    }
}