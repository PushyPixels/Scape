using UnityEngine;
using System.Collections;

public class OctoPushyDeath : Death
{
	public override void Die()
	{
		Destroy(gameObject);
	}
}
