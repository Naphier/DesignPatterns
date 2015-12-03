using UnityEngine;
using System.Collections;

public class WeaponComponent : MonoBehaviour {
    public Transform firePosition;
    public float rof = 1.0f;
    public string weaponName;
    public int damagePerShot = 20;
    public int totalAmmo = 100;
    public int maxAmmoPerClip = 20;
    public float range = 100f;
    public Texture2D crosshair;

    protected Ray shootRay;
    protected RaycastHit shootHit;

    float timer;
    int ammo;
    bool canFire = true;
    bool hasAmmo = true;
    bool hasClips = true;
    bool isActive = true;
    bool ownerIsPlayer = true;
    CharacterComponent owner;

    public bool CanFire() { return canFire; }
    public bool IsActive() { return isActive; }
    public bool HasClips() { return hasClips; }
    public bool HasAmmo() { return hasAmmo; }
    public int GetAmmo() { return ammo; }

    public virtual void Deactivate()
    {
        isActive = false;
    }

    public virtual void Activate()
    {
        isActive = true;
    }

    public virtual void Awake()
    {
        ammo = maxAmmoPerClip;
        owner = GetComponent<CharacterComponent>();
        timer = rof;
        ammo = maxAmmoPerClip;
    }

    public virtual void Fire()
    {
        if(canFire)
        {
            owner.Notify(gameObject, EVENTS.FIRED);
            canFire = false;
            timer = 0;
            ammo--;
            Debug.Log("Ammo: " + ammo);
        }
        else
        {
            
        }
    }

    public virtual void Reload()
    {
        if(totalAmmo > 0)
        {
            int ammoSpent = maxAmmoPerClip - ammo;
            if(ammoSpent > totalAmmo)
            {
                totalAmmo = 0;
                ammo += totalAmmo;
            }
            else
            {
                totalAmmo -= ammoSpent;
                ammo = maxAmmoPerClip;
            }
            owner.Notify(gameObject, EVENTS.RELOADED);
            Debug.Log("Total Ammo: " + totalAmmo);
        }
    }
	
	protected virtual void Update () 
    {
        if(!canFire && timer > rof)
        {
            canFire = true;
        }

        if(ammo < 1)
        {
            hasAmmo = false;
        }

        if(!hasAmmo)
        {
            canFire = false;
        }
        timer += Time.deltaTime;
	}
}
