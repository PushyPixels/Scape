using UnityEngine;
using System.Collections;

public class ProjectileSkill : Skill
{
	public DamageInfo projectile;
	public float cooldown = 0.1f;
	public Transform shootLocation;

	private bool canShoot = true;


	// Use this for initialization
	void Start ()
	{
		if(shootLocation == null)
		{
			shootLocation = transform;
		}
	}

	void ResetShot ()
	{
		canShoot = true;
	}

	public override void Cast()
	{
		if(canShoot)
		{
			DamageInfo instance = Instantiate(projectile,shootLocation.position,transform.rotation) as DamageInfo;

			Weapon wep = PlayerEquipment.Instance.currentWeapon;
			instance.minDamage = wep.minDamage * damagePercentage;
			instance.maxDamage = wep.maxDamage * damagePercentage;
			
			canShoot = false;
			Invoke("ResetShot",cooldown);
		}
	}
}
