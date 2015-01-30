using UnityEngine;
using System.Collections;

public class DebugDeath : Death
{
	public override void Die ()
	{
		base.Die();
		Destroy(gameObject);
	} 
}
