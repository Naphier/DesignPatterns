using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    CharacterCommand fireCommand = new FireCommand(null);
    CharacterCommand jumpCommand = new JumpCommand(null);
    CharacterCommand currentCommand;

	public GameObject player;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

    bool defaultKeys = false;
	void Update () 
	{
		currentCommand = HandleInput();
		if(currentCommand != null)
		{
			currentCommand.Execute(player);
		}

        // Test reassignment of keys
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            if (!defaultKeys)
            {
                KeyCode fireKey = KeyCode.UpArrow;
                KeyCode jumpKey = KeyCode.LeftControl;
                
                Debug.LogWarning("Assigning new keys - jump is: " + jumpKey.ToString() + " --  fire is: " + fireKey);
                fireCommand.SetInputKey(() => Input.GetKey(fireKey));
                jumpCommand.SetInputKey(() => Input.GetKeyDown(jumpKey));
            }
            else
            {
                Debug.LogWarning("Resetting keys to default");
                fireCommand.SetInputKey(fireCommand.DefaultInput);
                jumpCommand.SetInputKey(jumpCommand.DefaultInput);
            }

            defaultKeys = !defaultKeys;
        }
	}


    CharacterCommand HandleInput()
	{
		if(fireCommand.GetInput()) { return fireCommand; }
		if(jumpCommand.GetInput()) { return jumpCommand; }

		return null;
	}
}
