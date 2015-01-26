using UnityEngine;
using System.Collections;

public class RotateAroundAxis : MonoBehaviour
{
	public Vector3 axis = Vector3.up;
	public float speed = 30.0f;
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround(transform.position,axis,speed*Time.deltaTime);
	}
}
