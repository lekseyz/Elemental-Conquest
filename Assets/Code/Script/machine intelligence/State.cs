using UnityEngine;

public abstract class State
{
    protected Patroler patroler;

    public State(Patroler patroler)
    {
        this.patroler = patroler;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
