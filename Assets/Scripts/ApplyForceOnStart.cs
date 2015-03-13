using UnityEngine;
using System.Collections;

public class ApplyForceOnStart : MonoBehaviour
{
	public Vector3 forceDirection = Vector3.forward;
	public float forceAmount = 10.0f;
	public ForceMode forceMode;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody>().AddRelativeForce(forceDirection.normalized*forceAmount,forceMode);
	}
}
