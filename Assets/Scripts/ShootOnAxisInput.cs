using UnityEngine;
using System.Collections;

public class ShootOnAxisInput : MonoBehaviour
{
	//public Skill currentSkill;
	public Skill[] skillList;
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string switchSkillButton = "Fire1";

	private int selectedSkill = 0;

	// Update is called once per frame
	void Update ()
	{
		Vector3 shootDirection = Vector3.right*Input.GetAxis(horizontalAxis) + Vector3.forward*Input.GetAxis(verticalAxis);
		if(shootDirection.sqrMagnitude > 0.0f)
		{
			transform.rotation = Quaternion.LookRotation(shootDirection,Vector3.up);

			skillList[selectedSkill].Cast();
		}

		if(Input.GetButtonDown(switchSkillButton))
		{
			selectedSkill++;
			if(selectedSkill >= skillList.Length)
			{
				selectedSkill = 0;
			}
		}
	}
}
