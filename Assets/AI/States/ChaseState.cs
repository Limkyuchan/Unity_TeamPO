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
        // �÷��̾ ���� �̵�
        //enemy.transform.position = Vector3.MoveTowards(
        //    enemy.transform.position,
        //    Player.Instance.transform.position,
        //    Time.deltaTime * 3f // ���� �ӵ�
        //);

        // ���� ��Ÿ� ���� ���� ���� ��ȯ
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