using UnityEngine;
using UnityEngine.AI;

public interface IMovementStrategy
{
    void Move(NavMeshAgent agent, Vector3 targetPosition);
}