using UnityEngine;
using System.Collections;

public class PlayerLevel : MonoBehaviour
{
	public static PlayerLevel Instance;

	[Header("Tweak Variables")]
	public float perLevelBonusPercentage = 0.1f; //Ten percent
	public int perLevelAttackRatingIncrease = 10;
	public int perLevelDefenceRatingIncrease = 10;

	[Header("In-Game Variables")]
	public float damageBonusPercentage = 1.0f;
	public int attackRating = 20;
	public int defenseRating = 20;
	public int currentLevel = 1;
	public int maxLevel = 70;
	public int XP = 0;

	public static void AddXP(int amount)
	{
		Instance.XP += amount;
		while(Instance.XP > GetNextLevelXPRequirement())
		{
			LevelUp();
		}
		if(Instance.currentLevel > Instance.maxLevel)
		{
			Instance.currentLevel = Instance.maxLevel;
		}
	}

	public static void LevelUp()
	{
		Instance.currentLevel++;
		Instance.damageBonusPercentage += Instance.perLevelBonusPercentage;
		Instance.attackRating += Instance.perLevelAttackRatingIncrease;
		Instance.defenseRating += Instance.perLevelDefenceRatingIncrease;
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
		GUILayout.Label("XP: " + XP);
		GUILayout.Label("Next level at: " + GetNextLevelXPRequirement());
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
