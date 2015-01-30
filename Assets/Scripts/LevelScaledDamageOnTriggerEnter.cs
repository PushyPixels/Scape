using UnityEngine;
using System.Collections;

public class LevelScaledDamageOnTriggerEnter : MonoBehaviour
{
	public float damageBonus = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
	{
		col.SendMessageUpwards("Damage",damageBonus*PlayerLevel.Instance.currentLevel,SendMessageOptions.DontRequireReceiver);
	}
}
