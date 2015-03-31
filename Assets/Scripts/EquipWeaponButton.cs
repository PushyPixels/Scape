using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EquipWeaponButton : MonoBehaviour
{
	public Weapon associatedWeapon;
	public static Button selectedWeaponButton;

	public void EquipWeapon()
	{
		if(selectedWeaponButton)
		{
			selectedWeaponButton.interactable = true;
		}

		PlayerEquipment.Instance.currentWeapon = associatedWeapon;

		Button button = GetComponent<Button>();
		button.interactable = false;
		selectedWeaponButton = button;
	}
}
