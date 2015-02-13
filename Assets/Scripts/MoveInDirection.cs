using UnityEngine;
using System.Collections;

public class MoveInDirection : MonoBehaviour
{
	public Vector3 speed = Vector3.one;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += speed*Time.deltaTime;
	}
}
