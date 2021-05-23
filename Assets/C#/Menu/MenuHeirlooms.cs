using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuHeirlooms : MonoBehaviour
{
    
	[SerializeField]
	UIHeirloom[] UIHeirlooms;



	void Start()
	{
		foreach(var h in UIHeirlooms)
		{
			if(!Heirlooms.collectedHeirlooms.Contains(h.name))
			{
				foreach(Transform c in h.display.transform)
				{
					c.gameObject.SetActive(false);
				}
				
				//h.display.SetActive(false);
			}
		}
	}



	[Serializable]
	class UIHeirloom
	{
		public string name;
		public GameObject display;
	}
}
