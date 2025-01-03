using UnityEngine;
using UnityEngine.AI;

public interface IAttackStrategy
{
    void Attack(CharacterType type, NavMeshAgent agent, Transform target);
}