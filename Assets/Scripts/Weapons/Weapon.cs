using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public float minDamage = 1.0f;
	public float maxDamage = 10.0f;

	public virtual float WeaponDamage()
	{
		return Random.Range(minDamage,maxDamage);
	}
}
