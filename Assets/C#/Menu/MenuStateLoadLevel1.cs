using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateLoadLevel1 : MenuState
{
  
	string sceneName = "Level 1 Farms";
	float startTime = Mathf.Infinity;



   	public override void RunState()
	{
		if(startTime + blackboard.loadDelay < Time.time)
		{
			SceneLoader.LoadLevel(sceneName);
		}
	}



	public override void StartState()
	{
		blackboard.aud.PlayOneShot(blackboard.clickSound);
		blackboard.aud.PlayOneShot(blackboard.loadSound);
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