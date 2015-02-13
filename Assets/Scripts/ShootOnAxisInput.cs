using UnityEngine;
using System.Collections;

public class ShootOnAxisInput : MonoBehaviour
{
	public Skill currentSkill;
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";

	private bool canShoot = true;
	

	// Update is called once per frame
	void Update ()
	{
		Vector3 shootDirection = Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis);
		if(shootDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(shootDirection,Vector3.up);

			currentSkill.Cast();
		}
	}
}
