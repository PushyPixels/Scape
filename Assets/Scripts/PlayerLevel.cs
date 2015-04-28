using UnityEngine;
using System.Collections;

public class PlayerLevel : MonoBehaviour
{
	public static PlayerLevel Instance;

	[Header("Tweak Variables")]
	public float perLevelDamageBonusPercentage = 0.1f; //Ten percent
	public int perLevelAttackRatingIncrease = 10;
	public int perLevelDefenceRatingIncrease = 10;
	public float perLevelHealthIncrease = 10.0f;

	[Header("In-Game Variables")]
	[SerializeField] private int currentLevel = 1;
	[SerializeField] private int XP = 0;
	[SerializeField] private float HP;
	[SerializeField] private float damageBonusPercentage = 1.0f;
	[SerializeField] private int attackRating = 20;
	[SerializeField] private int defenseRating = 20;
	[SerializeField] private int maxLevel = 70;
	[SerializeField] private bool isDead = false;
	
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
		Instance.damageBonusPercentage += Instance.perLevelDamageBonusPercentage;
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

	void Damage(float amount)
	{
		HP -= amount;
		if(HP <= 0.0f && !isDead)
		{
			Death();
			isDead = true;
		}
	}

	void Death()
	{
		GetComponent<Death>().Die();
	}

	
	// Update is called once per frame
	void Update()
	{
	
	}
}
