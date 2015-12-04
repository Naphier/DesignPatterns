using UnityEngine;


// Since this is not an interface or abstract it should function as our base class
// with all necessary defaults and commonalities for CharacterCommands
public class CharacterCommand
{
    protected CharacterComponent _actor;

    public delegate bool InputDelegate();
    protected InputDelegate Input;
    public InputDelegate DefaultInput { get; private set; }


    // This will force each subclass to define a constructor with this minimal parameter.
    // All character commands need an input.
    public CharacterCommand(InputDelegate inputDelegate)
    {
        if (inputDelegate != null)
            SetInputKey(inputDelegate);
    }

    
    public virtual void Execute(GameObject actor)
    {
        if (_actor != actor)
            _actor = actor.GetComponent<CharacterComponent>();
    }


    public bool GetInput()
    {
        if (Input != null)
            return Input();
        
        return false;
    }

    public void SetInputKey(InputDelegate action)
    {
        Input = null;
        Input += action;

        if (DefaultInput == null)
            DefaultInput += action;
    }
}


// Now each of our derived commands are very minimalized and easy to create many of them.
public class JumpCommand : CharacterCommand
{
    //Assign default key if constructor parameter is null
    public JumpCommand(InputDelegate input) : base(input)
    {
        if (input == null)
            SetInputKey( () => UnityEngine.Input.GetKeyDown(KeyCode.Space));
    }

	public override void Execute(GameObject actor)
	{
        base.Execute(actor);
        _actor.Jump();
	}
}


public class FireCommand : CharacterCommand
{
    //Assign default key if constructor parameter is null
    public FireCommand(InputDelegate input) : base(input)
    {
        if (input == null)
            SetInputKey(() => UnityEngine.Input.GetMouseButton(0));
    }

    public override void Execute (GameObject actor)
	{
        base.Execute(actor);
        _actor.Fire();
	}
}
