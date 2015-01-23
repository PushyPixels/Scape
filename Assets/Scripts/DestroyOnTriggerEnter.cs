using UnityEngine;
using System.Collections;

public class DestroyOnTriggerEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter()
	{
		Destroy (gameObject);
	}
}
