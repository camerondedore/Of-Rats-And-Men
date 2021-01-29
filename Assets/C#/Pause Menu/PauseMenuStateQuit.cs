using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuStateQuit : PauseMenuState
{
  
	
	float startTime = Mathf.Infinity;



   	public override void RunState()
	{
		if(startTime + blackboard.quitDelay < Time.unscaledTime)
		{
			SceneLoader.Quit();
		}
	}



	public override void StartState()
	{
		startTime = Time.unscaledTime;
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
