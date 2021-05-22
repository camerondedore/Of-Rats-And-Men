using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateControls : MenuState
{
    




   	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.aud.PlayOneShot(blackboard.clickSound);
		blackboard.controlsWindow.SetActive(true);
	}



	public override void EndState()
	{
		blackboard.controlsWindow.SetActive(false);
	}



	public override State Transition()
	{
		return this;
	}
}
