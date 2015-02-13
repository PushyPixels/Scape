using UnityEngine;
using System.Collections;

public class ProjectileSkill : Skill
{
	public DamageOnTriggerEnter projectile;
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
			DamageOnTriggerEnter instance = Instantiate(projectile,transform.position,transform.rotation) as DamageOnTriggerEnter;
			instance.damageAmount = 1.0f * damagePercentage; //This needs to pull from the current equipment information/damage
			
			canShoot = false;
			Invoke("ResetShot",cooldown);
		}
	}
}
