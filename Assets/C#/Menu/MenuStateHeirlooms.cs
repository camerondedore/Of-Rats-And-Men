using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateHeirlooms : MenuState
{
    




   	public override void RunState()
	{

	}



	public override void StartState()
	{
		blackboard.aud.PlayOneShot(blackboard.clickSound);
		blackboard.heirloomsWindow.SetActive(true);
	}



	public override void EndState()
	{
		blackboard.heirloomsWindow.SetActive(false);
	}



	public override State Transition()
	{
		return this;
	}
}
