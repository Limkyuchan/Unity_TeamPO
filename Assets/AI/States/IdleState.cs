using UnityEngine;

public class IdleState : ICharacterAI
{
    public void EnterState()
    {
        Debug.Log("Entered Idle State");
    }

    public void Execute()
    {
        Debug.Log("Execute Idle State");
        // �÷��̾ �����ϸ� ���� ��ȯ
        //if (enemy.FindPlayer())
        //{
        //    enemy.SwitchState(new ChaseState());
        //}
    }

    public void ExitState()
    {
        Debug.Log("Exiting Idle State");
    }
}