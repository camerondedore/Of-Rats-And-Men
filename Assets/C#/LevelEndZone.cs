using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndZone : MonoBehaviour
{
    
	[SerializeField]
	Animator uiAnim;
	[SerializeField]
	string nextLevelName = "";
	float animTime = 1.75f,
		triggerTime = Mathf.Infinity;



	void Update()
	{
		if(triggerTime + animTime < Time.time)
		{
			SceneLoader.LoadLevel(nextLevelName);
		}
	}



	void OnTriggerEnter()
	{
		triggerTime = Time.time;
		uiAnim.SetTrigger("load");
	}
}
