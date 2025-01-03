using UnityEngine;
using UnityEngine.AI;

public class BasicAttack : IAttackStrategy
{
    public void Attack(CharacterType type, NavMeshAgent agent, Transform target)
    {
        if (type == CharacterType.Player)
        {
            Debug.Log("Player ------- Basic Attack");
        }
        else if (type == CharacterType.Enemy)
        {
            Debug.Log("Enemy ------- Basic Attack");
        }
    }
}