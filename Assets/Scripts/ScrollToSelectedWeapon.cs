using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScrollToSelectedWeapon : MonoBehaviour
{
	private ScrollRect scroll;
	private RectTransform scrollTransform;
	
	void Start()
	{
		scroll = GetComponent<ScrollRect>();
		scrollTransform = GetComponent<RectTransform>();
	}
	
	public void CenterToItem(RectTransform obj)
	{
		float normalizePosition = scrollTransform.anchorMin.y - obj.anchoredPosition.y;
		normalizePosition += (float)obj.transform.GetSiblingIndex() / (float)scroll.content.transform.childCount;
		normalizePosition /= 100f; //I think this is related to the pixels per unit setting actually
		normalizePosition = Mathf.Clamp01(1 - normalizePosition);
		scroll.verticalNormalizedPosition = normalizePosition;
		Debug.Log(normalizePosition);
	}
}


