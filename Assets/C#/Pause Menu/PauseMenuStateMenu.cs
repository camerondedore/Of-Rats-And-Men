using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuStateMenu : PauseMenuState
{
  
	string sceneName = "Menu";
	float startTime = Mathf.Infinity;



   	public override void RunState()
	{
		if(startTime + blackboard.loadDelay < Time.unscaledTime)
		{
			blackboard.pauser.PauseSet(false);
			SceneLoader.LoadLevel(sceneName);
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
