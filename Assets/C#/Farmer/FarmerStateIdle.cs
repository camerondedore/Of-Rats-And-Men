using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerStateIdle : FarmerState
{
    
	float startTime,
		rakeTime;




	public override void RunState()
	{

	}



	public override void StartState()
	{
		startTime = Time.time;
		rakeTime = Random.Range(6f, 15f);
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.time > startTime + rakeTime)
		{
			return blackboard.scoopState;
		}

		return this;
	}
}
