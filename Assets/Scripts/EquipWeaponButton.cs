using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipWeaponButton : MonoBehaviour
{
	public void EquipWeapon()
	{
		Weapon weapon = GetComponent<Weapon>();

		Button oldButton = PlayerEquipment.Instance.currentWeapon.GetComponent<Button>();
		if(oldButton)
		{
			oldButton.interactable = true;
		}

		PlayerEquipment.Instance.currentWeapon = weapon;

		Button button = GetComponent<Button>();
		button.interactable = false;
	}
}
