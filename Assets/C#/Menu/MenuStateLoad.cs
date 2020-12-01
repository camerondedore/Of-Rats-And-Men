using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStateLoad : MenuState
{
  
	float startTime = Mathf.Infinity;



   	public override void RunState()
	{

	}



	public override void StartState()
	{
		startTime = Time.time;
		// fade out ui animation
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		return this;
	}
}
