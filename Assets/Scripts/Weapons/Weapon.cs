using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
	public string weaponName = "FUntitledWeapon";
	public float minDamage = 1.0f;
	public float maxDamage = 10.0f;


	public abstract float WeaponDamage();
	/*
	{
		return Random.Range(minDamage,maxDamage);
	}
	*/
}
