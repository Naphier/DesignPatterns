using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {

	Command MOUSE_BUTTON0;
	Command SPACE_BAR;
	Command currentCommand;

	public GameObject player;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () 
	{
		MOUSE_BUTTON0 = new FireCommand();
		SPACE_BAR = new JumpCommand();
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentCommand = HandleInput();
		if(currentCommand != null)
		{
			currentCommand.Execute(player);
		}
	}

	Command HandleInput()
	{
		if(Input.GetMouseButton(0)) { return MOUSE_BUTTON0; }
		if(Input.GetKeyDown(KeyCode.Space)) { return SPACE_BAR; }

		return null;
	}
}
