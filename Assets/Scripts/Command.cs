using UnityEngine;
using System.Collections;

public class Command 
{
	public virtual void Execute(GameObject actor){}	
}

public class JumpCommand : Command 
{
	public override void Execute(GameObject actor)
	{
		actor.GetComponent<CharacterComponent>().Jump();
	}
}

public class FireCommand : Command
{
	public override void Execute (GameObject actor)
	{
		/*
		 * To do: 
		 * 	create a base character class that can
		 * 	check to see if a character is capable of firing a weapon
		 *  and if that character wants to fire, then fire
		 */

		actor.GetComponent<CharacterComponent>().Fire();
	}
}
