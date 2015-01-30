using UnityEngine;
using System.Collections;

public class SpawnAfterDelay : MonoBehaviour
{
	public GameObject objectToSpawn;
	public float delay = 1.0f;

	// Use this for initialization
	void Start ()
	{
		Invoke("Spawn",delay);
	}

	void Spawn()
	{
		Instantiate(objectToSpawn,transform.position,transform.rotation);
		Invoke("Spawn",delay);
	}
}
