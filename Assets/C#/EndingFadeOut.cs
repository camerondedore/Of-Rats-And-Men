using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingFadeOut : MonoBehaviour
{
    
	[SerializeField]
	float fadeDelay = 9,
		animTime = 1.75f;
	Animator anim;
	float startTime = Mathf.Infinity;
	bool triggered = false;



    void Start()
    {
        startTime = Time.time;
		anim = GetComponent<Animator>();
    }



    void Update()
    {
        if(!triggered && startTime + fadeDelay < Time.time)
		{
			triggered = true;
			anim.SetTrigger("exit");
		}

		if(triggered && startTime + fadeDelay + animTime < Time.time)
		{
			SceneLoader.LoadLevel("Menu");
		}
    }
}
