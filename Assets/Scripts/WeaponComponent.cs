using UnityEngine;
using System.Collections;

public class WeaponComponent : MonoBehaviour {
    public Transform firePosition;
    public string weaponName;
    public int damagePerShot = 20;
    public int maxAmmoPerClip = 20;
    public int clips;
    public float range = 100f;
    public Texture2D crosshair;

    protected Ray shootRay;
    protected RaycastHit shootHit;

    int ammo;
    bool canFire = true;
    bool hasAmmo = true;
    bool hasClips = true;
    bool isActive = true;
    GameObject owner;

    public bool CanFire() { return canFire; }
    public bool IsActive() { return isActive; }
    public GameObject GetOwner() { return owner; }
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
    }

    public virtual void Fire()
    {
        if(canFire)
        {
            Debug.Log("Player is firing");
        }
    }

    public virtual void Reload()
    {
        if(hasClips)
        {
            
        }
    }

	void Start () 
    {
	
	}
	
	protected virtual void Update () 
    {
        if(ammo < 1)
        {
            hasAmmo = false;
            canFire = false;
        }

        if(clips < 1)
        {
            hasClips = false;
            canFire = false;
        }
	}
}
