using UnityEngine;
using System.Collections;

public class MoveOnAxisInput : MonoBehaviour
{
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public float speed = 1.0f;
	public LayerMask layerMask = -1;
	public float maxRotationSpeed = 90.0f;
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 shootDirection = Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis);
		if(shootDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(shootDirection,Vector3.up),maxRotationSpeed*Time.deltaTime);
		}

		transform.position += shootDirection.normalized*speed*Time.deltaTime;
	}
}
