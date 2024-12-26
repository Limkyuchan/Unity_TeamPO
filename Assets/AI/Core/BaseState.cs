public abstract class BaseState
{
    public virtual void EnterState() { }

    public abstract void UpdateState();

    public virtual void ExitState() { }
}