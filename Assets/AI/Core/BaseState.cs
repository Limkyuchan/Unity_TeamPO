using UnityEngine.AI;
using UnityEngine;

public abstract class BaseState
{
    public virtual void EnterState() { }

    public abstract void UpdateState();

    public virtual void ExitState() { }
}