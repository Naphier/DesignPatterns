using UnityEngine;
public class Command
{
	public virtual void Execute(GameObject actor){}
}

public class FireCommand : Command
{
    CharacterComponent _actor;
    public override void Execute (GameObject actor)
	{
        if (_actor != actor) _actor = actor.GetComponent<CharacterComponent>();
        _actor.Fire();
	}
}

public class ReloadCommand : Command
{
    CharacterComponent _actor;
    public override void Execute(GameObject actor)
    {
        if (_actor != actor) _actor = actor.GetComponent<CharacterComponent>();
        _actor.Reload();
    }
}
