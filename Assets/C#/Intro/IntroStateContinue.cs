using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStateContinue : IntroState
{
    
	float startTime = Mathf.Infinity;



   	public override void RunState()
	{
		if(startTime + blackboard.loadDelay < Time.time)
		{
			SceneLoader.LoadLevel(blackboard.menuScene);
		}
	}



	public override void StartState()
	{
		blackboard.aud.PlayOneShot(blackboard.clickSound);
		startTime = Time.time;
		blackboard.fadeAnim.SetTrigger("exit");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		return this;
	}
}
