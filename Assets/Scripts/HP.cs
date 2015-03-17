using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HP : MonoBehaviour
{
	public Image healthBarPrefab;
	public Gradient healthBarColors;
	public Transform healthBarPosition;
	public float maxHealth = 1.0f;

	private bool isDead = false;

	private float currentHealth;
	private Image healthBarInstance;

	// Use this for initialization
	void Start ()
	{
		healthBarInstance = Instantiate(healthBarPrefab,healthBarPosition.position,healthBarPrefab.transform.rotation) as Image;
		healthBarInstance.transform.SetParent(GameObject.FindGameObjectWithTag("CanvasWorldSpace").transform,false);
		currentHealth = maxHealth;
		healthBarInstance.fillAmount = currentHealth/maxHealth;
		healthBarInstance.color = healthBarColors.Evaluate(healthBarInstance.fillAmount);
	}

	void Update()
	{
		//Reposition the health bar
		healthBarInstance.transform.position = healthBarPosition.position;

		//Rotate it properly, we are skipping this because we have a fixed view that looks down the z axis of our world!
	}

	void Damage(float amount)
	{
		currentHealth -= amount;

		//Set health bar based on HP and remaining HP
		healthBarInstance.fillAmount = currentHealth/maxHealth;
		healthBarInstance.color = healthBarColors.Evaluate(healthBarInstance.fillAmount);

		if(currentHealth <= 0.0f && !isDead)
		{
			Death();
			isDead = true;
		}
	}

	void Death()
	{
		GetComponent<Death>().Die();
	}
}
