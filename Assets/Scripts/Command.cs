using UnityEngine;

public class Command
{
    public virtual void Execute(GameObject actor)
    {
    }
}

public class JumpCommand : Command
{
    private CharacterComponent _actor;

    public override void Execute(GameObject actor)
    {
        if (_actor != actor) _actor = actor.GetComponent<CharacterComponent>();
        _actor.Jump();
    }
}

public class FireCommand : Command
{
    private CharacterComponent _actor;

    public override void Execute(GameObject actor)
    {
        if (_actor != actor) _actor = actor.GetComponent<CharacterComponent>();
        _actor.Fire();
    }
}