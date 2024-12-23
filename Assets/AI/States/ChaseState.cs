using UnityEngine;

public class ChaseState : ICharacterAI
{
    public void EnterState()
    {
        Debug.Log("Entered Chase State");
    }

    public void Execute()
    {
        Debug.Log("Execute Chase State");
        // 플레이어를 따라 이동
        //enemy.transform.position = Vector3.MoveTowards(
        //    enemy.transform.position,
        //    Player.Instance.transform.position,
        //    Time.deltaTime * 3f // 추적 속도
        //);

        // 공격 사거리 내에 들어가면 상태 전환
        //    if (Vector3.Distance(enemy.transform.position, Player.Instance.transform.position) < 2f)
        //    {
        //        enemy.SwitchState(new AttackState());
        //    }
    }

    public void ExitState()
    {
        Debug.Log("Exiting Chase State");
    }
}