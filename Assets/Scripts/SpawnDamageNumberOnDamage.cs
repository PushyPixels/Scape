using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnDamageNumberOnDamage : MonoBehaviour
{
	public Text damageTextObject;
	private GameObject damageCanvas;

	// Use this for initialization
	void Start ()
	{
		damageCanvas = GameObject.FindGameObjectWithTag("DamageCanvas");
	}
	
	void Damage(float amount)
	{
		Text instance = Instantiate(damageTextObject,transform.position,damageTextObject.transform.rotation) as Text;
		instance.text = ((int)amount).ToString();
		instance.transform.parent = damageCanvas.transform;
	}
}
