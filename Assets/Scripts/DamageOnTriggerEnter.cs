using UnityEngine;
using System.Collections;

public class DamageOnTriggerEnter : MonoBehaviour
{
	private DamageInfo damageInfo;

	// Use this for initialization
	void Start ()
	{
		damageInfo = GetComponent<DamageInfo>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
	{
		col.BroadcastMessage("Damage",damageInfo.RollDamage(),SendMessageOptions.DontRequireReceiver);
	}
}
