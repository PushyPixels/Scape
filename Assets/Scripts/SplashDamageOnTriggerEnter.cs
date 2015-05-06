using UnityEngine;
using System.Collections;

public class SplashDamageOnTriggerEnter : MonoBehaviour
{
	public GameObject effect;
	public float radius = 1.0f;
	public LayerMask layerMask = -1;

	private DamageInfo damageInfo;
	
	// Use this for initialization
	void Start ()
	{
		damageInfo = GetComponent<DamageInfo>();
	}

	void OnTriggerEnter()
	{
		//Instantiate our effect
		Instantiate(effect,transform.position,Quaternion.identity);

		//Do the damage
		foreach(Collider col in Physics.OverlapSphere(transform.position,radius,layerMask))
		{
			col.BroadcastMessage("Damage",damageInfo.RollDamage(),SendMessageOptions.DontRequireReceiver);
		}
	}
}
