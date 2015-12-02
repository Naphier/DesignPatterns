using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// don't attach this to a game object
public class CharacterComponent: MonoBehaviour
{
	protected List<Observer> observers = new List<Observer>();

	protected void Notify(GameObject actor, EVENTS e)
	{
		foreach(Observer o in observers)
		{
			o.OnNotify(actor, e);
		}
	}

	public virtual void Fire() 
	{
		Notify(gameObject, EVENTS.FIRED);
	}
	public virtual void Jump() 
	{
		Notify(gameObject, EVENTS.JUMPED);
	}
}
