using UnityEngine;
using System.Collections;

public class TestWeapon : Weapon
{
	public override float WeaponDamage()
	{
		return Random.Range(minDamage,maxDamage);
	}
}
