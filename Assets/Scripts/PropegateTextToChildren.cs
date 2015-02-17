using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PropegateTextToChildren : MonoBehaviour
{
	//LateUpdate is called once per frame, after all Updates complete
	void LateUpdate ()
	{
		string initialText = GetComponent<Text>().text;

		foreach(Text text in GetComponentsInChildren<Text>())
		{
			text.text = initialText;
		}
	}
}
