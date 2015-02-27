using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	public int XPValue = 1;
	public float dropPercentage = 0.5f;

	public virtual void Die()
	{
		PlayerLevel.AddXP(XPValue);
		if(Random.value <= dropPercentage)
		{
			WeaponGenerator.Instance.GenerateWeapon();
		}
	}
}
