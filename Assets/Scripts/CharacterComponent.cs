using UnityEngine;
using System.Collections.Generic;
// don't attach this to a game object
public abstract class CharacterComponent: MonoBehaviour
{
    protected WeaponComponent activeWeapon;
	protected List<Observer> Observers = new List<Observer>();

	public void Notify(GameObject actor, EVENTS e)
	{
		for (var i = 0; i < Observers.Count; i++)
			Observers[i].OnNotify(actor, e);
	}

	public virtual void Fire() { }
    public virtual void Reload() { }
}
