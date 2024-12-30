using UnityEngine;
using UnityEngine.AI;

public class AvoidMovement : IMovementStrategy
{
    public void Move(NavMeshAgent agent, Vector3 targetPosition)
    {
        float speed = 12f;
        agent.speed = speed;

        Vector3 direction = (agent.transform.position - targetPosition).normalized;
        agent.SetDestination(agent.transform.position + direction * 6f);        // 회피 거리 설정
    }
}