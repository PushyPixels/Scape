﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponGenerator : MonoBehaviour
{
	public static WeaponGenerator Instance;

	public GameObject buttonPrefab;
	public string[] wordList;
	public int maxWords = 3;
	public int minDamage = 1;
	public int maxDamage = 10;
	public string damageSuffix = " Damage";

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

	// Use this for initialization
	void Start ()
	{
		Weapon weapon = GenerateWeapon();
		PlayerEquipment.Instance.currentWeapon = weapon;
		weapon.GetComponent<Button>().interactable = false;
	}

	public Weapon GenerateWeapon()
	{
		GameObject instance = Instantiate(buttonPrefab,Vector3.zero,Quaternion.identity) as GameObject;

		instance.transform.SetParent(transform,false);
		
		TestWeapon weapon = instance.AddComponent<TestWeapon>();
		
		foreach(Text text in instance.GetComponentsInChildren<Text>())
		{
			if(text.name == "Name")
			{
				string finalName = "";
				int num = Random.Range(1,maxWords+1);
				for(int j = 0; j < num; j++)
				{
					finalName += wordList[Random.Range(0,wordList.Length)] + " ";
				}
				
				weapon.weaponName = finalName;
				text.text = finalName;
			}
			else if(text.name == "Damage Range")
			{
				int weaponMinDamage = Random.Range(1,minDamage);
				int weaponMaxDamage = Random.Range(minDamage,maxDamage);
				string finalName = weaponMinDamage + "-" + weaponMaxDamage + damageSuffix;
				text.text = finalName;
				
				weapon.minDamage = weaponMinDamage;
				weapon.maxDamage = weaponMaxDamage;
			}
		}
		return weapon;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
