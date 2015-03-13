using UnityEngine;
using System.Collections;

public class ProjectileSkill : Skill
{
	public DamageInfo projectile;
	public float cooldown = 0.1f;

	private bool canShoot = true;


	// Use this for initialization
	void Start () {
	
	}

	void ResetShot ()
	{
		canShoot = true;
	}

	public override void Cast()
	{
		if(canShoot)
		{
			DamageInfo instance = Instantiate(projectile,transform.position,transform.rotation) as DamageInfo;

			Weapon wep = PlayerEquipment.Instance.currentWeapon;
			instance.damage = wep.WeaponDamage() * damagePercentage;
			
			canShoot = false;
			Invoke("ResetShot",cooldown);
		}
	}
}
