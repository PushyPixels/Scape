using UnityEngine;
using System.Collections;

public class CycleNoise : MonoBehaviour {

	public Texture2D[] noiseTextures;
	private SENaturalBloomAndDirtyLens se;
	private int index = 0;

	// Use this for initialization
	void Start ()
	{
		se = GetComponent<SENaturalBloomAndDirtyLens>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		se.lensDirtTexture = noiseTextures[index];
		index++;
		if(index >= noiseTextures.Length)
		{
			index = 0;
		}
	}
}
