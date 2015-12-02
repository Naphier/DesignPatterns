using UnityEngine;
using System.Collections;

public class PlayerComponent :  CharacterComponent 
{
	public override void Fire () 
	{
		Notify(gameObject, EVENTS.PLAYER_FIRED);
		base.Fire();
		Debug.Log("Firing " + name + "'s weapon.");
	}

	public override void Jump ()
	{
		Notify(gameObject, EVENTS.PLAYER_JUMPED);
		base.Jump();
		Debug.Log ("Make " + name + " jump.");
	}
	// Use this for initialization
	void Awake () 
	{
		observers.Add(new AchievementObserver());
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
	
}
