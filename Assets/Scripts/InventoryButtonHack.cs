using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryButtonHack : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		Canvas canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			Canvas canvas = GetComponent<Canvas>();
			canvas.enabled = !canvas.enabled;
		}
	}
}
