using UnityEngine;
using System.Collections;

public class PlayerComponent :  CharacterComponent
{
	public override void Fire ()
	{
        if(activeWeapon && activeWeapon.IsActive())
        {
            activeWeapon.Fire();
        }
		base.Fire();
	}

    public override void Reload()
    {
        if(activeWeapon && activeWeapon.IsActive())
        {
            activeWeapon.Reload();
        }
        base.Reload();
    }

	// Use this for initialization
	void Awake ()
	{
        activeWeapon = GetComponent<WeaponComponent>();
		Observers.Add(new AchievementObserver());

	}
	// Update is called once per frame
	void Update ()
	{

	}

}
