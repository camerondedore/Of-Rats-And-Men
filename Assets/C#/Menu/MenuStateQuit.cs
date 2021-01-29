using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateQuit : MenuState
{
    
	float startTime = Mathf.Infinity;



   	public override void RunState()
	{
		if(startTime + blackboard.quitDelay < Time.time)
		{
			SceneLoader.Quit();
		}
	}



	public override void StartState()
	{
		blackboard.thisMachine.frozen = true;
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
