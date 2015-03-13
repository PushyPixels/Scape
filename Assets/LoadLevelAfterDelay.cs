using UnityEngine;
using System.Collections;

public class LoadLevelAfterDelay : MonoBehaviour
{
	public string levelName;
	public float delay = 1.0f;

	// Use this for initialization
	void Start ()
	{
		Invoke("LoadLevel",delay);
	}

	void LoadLevel ()
	{
		Application.LoadLevel(levelName);
	}
}
