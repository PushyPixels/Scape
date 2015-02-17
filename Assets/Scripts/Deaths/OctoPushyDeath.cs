using UnityEngine;
using System.Collections;

public class OctoPushyDeath : Death
{
	public GameObject particleEffect;
	public string animationTrigger = "Death";

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public override void Die()
	{
		base.Die();
		animator.SetTrigger(animationTrigger);
		Instantiate(particleEffect,transform.position,transform.rotation);

		StartCoroutine(CheckAnimationDone());
	}

	IEnumerator CheckAnimationDone()
	{
		yield return null;
		while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f && !animator.IsInTransition(0))
		{
			yield return null;
		}

		Destroy(gameObject);
	}
}
