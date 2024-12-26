using UnityEngine;

public class AttackState : BaseState
{
    public override void EnterState()
    {
        Debug.Log("Entered Attack State");
    }

    public override void UpdateState()
    {
        Debug.Log("Execute Attack State");
    }

    public override void ExitState()
    {
        Debug.Log("Exiting Attack State");
    }
}