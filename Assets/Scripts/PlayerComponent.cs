using UnityEngine;
using System.Collections;

public class PlayerComponent :  MonoBehaviour, CharacterComponent {

	public void Fire () 
	{
		Debug.Log("Firing " + name + "'s weapon.");
	}
	public void Jump ()
	{
		Debug.Log ("Make " + name + " jump.");
	}
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
