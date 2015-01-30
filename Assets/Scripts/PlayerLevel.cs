using UnityEngine;
using System.Collections;

public class PlayerLevel : MonoBehaviour
{
	public static PlayerLevel Instance;

	public int currentLevel = 1;
	public int maxLevel = 70;

	private int _XP = 0;

	public static void AddXP(int amount)
	{
		Instance._XP += amount;
		while(Instance._XP > GetNextLevelXPRequirement())
		{
			Instance.currentLevel++;
		}
		if(Instance.currentLevel > Instance.maxLevel)
		{
			Instance.currentLevel = Instance.maxLevel;
		}
	}

	public static int GetNextLevelXPRequirement()
	{
		int returnValue = 10*Instance.currentLevel*Instance.currentLevel;
		return returnValue;
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

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnGUI()
	{
		GUILayout.Label("Level: " + currentLevel);
		GUILayout.Label("XP: " + _XP);
		GUILayout.Label("Next level at: " + GetNextLevelXPRequirement());
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
