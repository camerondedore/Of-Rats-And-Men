using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateSettings : MenuState
{
    




   	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.settingsWindow.SetActive(true);
	}



	public override void EndState()
	{
		blackboard.settingsWindow.SetActive(false);
	}



	public override State Transition()
	{
		return this;
	}
}
