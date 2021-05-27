using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerStateScoop : FarmerState
{
    
	float startTime,
		scoopTime = 3.95f;




	public override void RunState()
	{

	}



	public override void StartState()
	{
		startTime = Time.time;

		//animation
		blackboard.anim.SetTrigger("scoop");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.time > startTime + scoopTime)
		{
			return blackboard.idleState;
		}

		return this;
	}
}
