using UnityEngine;
using System.Collections;

public class PlayerEquipment : MonoBehaviour
{
	public static PlayerEquipment Instance;
	public Weapon currentWeapon;

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
