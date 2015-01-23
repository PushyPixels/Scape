using UnityEngine;
using System.Collections;

public class MoveOnAxisInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float speed = 1.0f;
	
	// Update is called once per frame
	void Update ()
	{
		//rigidbody.MovePosition(transform.position + (Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis)).normalized*speed*Time.deltaTime);

		Vector3 moveDirection = (Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis)).normalized*speed*Time.deltaTime;

		if(!Physics.Raycast(transform.position,moveDirection,1.0f))
		{
			transform.position += moveDirection;
		}
	}
}
