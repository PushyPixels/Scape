using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	public int XPValue = 1;

	public virtual void Die()
	{
		PlayerLevel.AddXP(XPValue);
	}
}
