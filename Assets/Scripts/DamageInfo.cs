using UnityEngine;
using System.Collections;

public class DamageInfo : MonoBehaviour
{
	public float minDamage;
	public float maxDamage;

	public float RollDamage()
	{
		return Random.Range(minDamage,maxDamage);
	}
}
