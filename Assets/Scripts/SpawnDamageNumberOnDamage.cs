using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnDamageNumberOnDamage : MonoBehaviour
{
	public static float runningAverage = 0;
	public static int numberOfHits = 0;
	public static int damageHistoryLength = 100;

	public float minSize = 0.025f;
	public float maxSize = 0.1f;
	public Text damageTextObject;
	private GameObject damageCanvas;

	// Use this for initialization
	void Start ()
	{
		damageCanvas = GameObject.FindGameObjectWithTag("CanvasWorldSpace");
	}
	
	void Damage(float amount)
	{
		//Calculate average damage to determine what's "big" vs "small"
		runningAverage += amount;
		numberOfHits++;

		if(numberOfHits > damageHistoryLength)
		{
			numberOfHits = damageHistoryLength;
			runningAverage -= runningAverage/100;
		}
		float averageDamage = runningAverage/numberOfHits;

		Text instance = Instantiate(damageTextObject,transform.position,damageTextObject.transform.rotation) as Text;
		instance.text = ((int)amount).ToString();
		instance.transform.SetParent(damageCanvas.transform,false);
		instance.transform.localScale = Vector3.one* Mathf.Lerp(minSize,maxSize,amount/(averageDamage*2));
	}
}
