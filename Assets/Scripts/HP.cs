using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour
{
	public float maxHealth = 1.0f;

	private bool isDead = false;

	private float currentHealth;

	// Use this for initialization
	void Start ()
	{
		currentHealth = maxHealth;
	}

	void Damage(float amount)
	{
		currentHealth -= amount;
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
