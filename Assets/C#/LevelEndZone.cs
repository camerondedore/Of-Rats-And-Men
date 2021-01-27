using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndZone : MonoBehaviour
{
    
	[SerializeField]
	Animator uiAnim;
	[SerializeField]
	AudioSourceController aud;
	[SerializeField]
	string nextLevelName = "";
	float animTime = 1.75f,
		triggerTime = Mathf.Infinity;
	bool loading = false;



	void Update()
	{
		if(loading && triggerTime + animTime < Time.time)
		{
			SceneLoader.LoadLevel(nextLevelName);
		}
	}



	void OnTriggerEnter()
	{
		if(!loading)
		{
			loading = true;
			triggerTime = Time.time;
			uiAnim.SetTrigger("load");
			aud.source.Play();
		}
	}
}
