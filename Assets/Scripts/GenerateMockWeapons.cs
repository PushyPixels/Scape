using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateMockWeapons : MonoBehaviour
{
	public GameObject buttonPrefab;
	public string[] wordList;
	public int maxWords = 3;
	public int minDamage = 1;
	public int maxDamage = 10;
	public int amount = 10;
	public string damageSuffix = " Damage";

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < amount; i++)
		{
			GameObject instance = Instantiate(buttonPrefab,Vector3.zero,Quaternion.identity) as GameObject;
			instance.transform.parent = transform;

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

					text.text = finalName;
				}
				else if(text.name == "Damage Range")
				{
					string finalName = Random.Range(1,minDamage) + "-" + Random.Range(minDamage,maxDamage) + damageSuffix;
					text.text = finalName;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
