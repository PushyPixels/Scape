using UnityEngine;
using System.Collections;

public class MoveOnAxisInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float speed = 1.0f;
	public LayerMask layerMask = -1;
	
	// Update is called once per frame
	void Update ()
	{
		//rigidbody.MovePosition(transform.position + (Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis)).normalized*speed*Time.deltaTime);

		Vector3 moveDirection = (Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis)).normalized*speed*Time.deltaTime;

		RaycastHit hit;
		if(Physics.Raycast(transform.position,moveDirection,out hit,1.0f,layerMask))
		{
			Vector3 tangent = Vector3.Cross(Vector3.Cross(hit.normal,moveDirection),hit.normal).normalized;

			/*
			Debug.DrawRay(transform.position,moveDirection.normalized,Color.yellow,1.0f);
			Debug.DrawRay(transform.position,hit.normal,Color.magenta,1.0f);
			Debug.DrawRay(transform.position,Vector3.Cross(hit.normal,moveDirection).normalized,Color.green,1.0f);
			Debug.DrawRay(transform.position,Vector3.Cross(Vector3.Cross(hit.normal,moveDirection),hit.normal).normalized,Color.red,1.0f);
			*/

			if(!Physics.Raycast(transform.position,tangent,1.0f,layerMask))
			{
				transform.position += tangent*speed*Time.deltaTime;
			}
		}
		else
		{
			transform.position += moveDirection;
		}

	}
}
