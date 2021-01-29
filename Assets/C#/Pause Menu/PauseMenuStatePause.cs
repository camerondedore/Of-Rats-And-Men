using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuStatePause : PauseMenuState
{





    public override void RunState()
	{
	
	}



	public override void StartState()
	{
		blackboard.menu.SetActive(true);
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.timeScale > 0)
		{
			return blackboard.playState;
		}

		return this;
	}
}
