using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour
{
	public float damagePercentage = 1.0f;

	public abstract void Cast();
}
