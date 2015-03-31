using UnityEngine;
using System.Collections;

public class TestWeapon : Weapon
{
	public TestWeapon(string newWeaponName = "FUntitledWeapon", float newMinDamage = 1.0f, float newMaxDamage = 10.0f) //Class constructor
	{
		weaponName = newWeaponName;
		minDamage = newMinDamage;
		maxDamage = newMaxDamage;
	}

	public override float WeaponDamage()
	{
		return Random.Range(minDamage,maxDamage);
	}
}
