using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour
{
	public string objectTag;
	public float speed = 1.0f;

	private GameObject objectReference;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(objectReference == null)
		{
			objectReference = GameObject.FindGameObjectWithTag(objectTag);
		}
		else
		{
			transform.position += (objectReference.transform.position - transform.position).normalized*speed*Time.deltaTime;
		}
	}
}
