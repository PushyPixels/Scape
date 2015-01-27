using UnityEngine;
using System.Collections;

public class DamageOnTriggerEnter : MonoBehaviour
{
	public float damageAmount = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
	{
		col.SendMessageUpwards("Damage",damageAmount,SendMessageOptions.DontRequireReceiver);
	}
}
