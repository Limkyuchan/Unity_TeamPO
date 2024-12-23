using UnityEngine;

public class AttackState : ICharacterAI
{
    public void EnterState()
    {
        Debug.Log("Entered Attack State");
    }

    public void Execute()
    {
        Debug.Log("Execute Attack State");

        // 플레이어가 사거리에서 벗어나면 상태 전환
        //if (Vector3.Distance(enemy.transform.position, Player.Instance.transform.position) > 2f)
        //{
        //    enemy.SwitchState(new ChaseState());
        //}
    }

    public void ExitState()
    {
        Debug.Log("Exiting Attack State");
    }
}