using UnityEngine;
using System.Collections;

public class EntityCollision : MonoBehaviour
{
	public float radius = 1.0f;
	public LayerMask layerMask = -1;
	private Vector3 lastPosition;

	// Use this for initialization
	void Start ()
	{
		lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(lastPosition != transform.position)
		{
			Vector3 moveDirection = transform.position - lastPosition;

			RaycastHit hit;
			if(Physics.Raycast(lastPosition,moveDirection,out hit,radius,layerMask))
			{
				Vector3 tangent = Vector3.Cross(Vector3.Cross(hit.normal,moveDirection),hit.normal).normalized;
				
				/*
				Debug.DrawRay(transform.position,moveDirection.normalized,Color.yellow,1.0f);
				Debug.DrawRay(transform.position,hit.normal,Color.magenta,1.0f);
				Debug.DrawRay(transform.position,Vector3.Cross(hit.normal,moveDirection).normalized,Color.green,1.0f);
				Debug.DrawRay(transform.position,Vector3.Cross(Vector3.Cross(hit.normal,moveDirection),hit.normal).normalized,Color.red,1.0f);
				*/
				
				if(!Physics.Raycast(lastPosition,tangent,radius,layerMask))
				{
					transform.position = lastPosition + tangent*Vector3.Project (moveDirection,tangent).magnitude;
				}
				else
				{
					transform.position = lastPosition;
				}
			}
		}

		lastPosition = transform.position;
	}
}
