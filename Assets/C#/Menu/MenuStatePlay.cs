using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatePlay : MenuState
{
    




   	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.aud.PlayOneShot(blackboard.clickSound);
		blackboard.levelSelectWindow.SetActive(true);
	}



	public override void EndState()
	{
		blackboard.levelSelectWindow.SetActive(false);
	}



	public override State Transition()
	{
		return this;
	}
}
