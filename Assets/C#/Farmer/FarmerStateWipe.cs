using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerStateWipe : FarmerState
{
    
	float startTime,
		wipeTime = 1.7f;




	public override void RunState()
	{

	}



	public override void StartState()
	{
		startTime = Time.time;

		// wipe timing
		blackboard.lastWipeTime = Time.time;
		blackboard.wipeTime = Random.Range(12f, 24f);

		//animation
		blackboard.anim.SetTrigger("wipe");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.time > startTime + wipeTime)
		{
			return blackboard.idleState;
		}

		return this;
	}
}
