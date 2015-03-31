using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerEquipment : MonoBehaviour
{
	public static PlayerEquipment Instance;
	public Weapon currentWeapon;

	private List<Weapon> inventory = new List<Weapon>();

	public Weapon AddWeapon(Weapon newWeapon)
	{
		inventory.Add(newWeapon);
		return newWeapon;
	}

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}
}
