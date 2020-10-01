using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenStatePreen : RavenState
{
        
	float preenStartTime = 0,
		preenTime = 1;


	
	public override void RunState()
	{

	}



	public override void StartState()
	{
		preenStartTime = Time.time;
		preenTime = Random.Range(1f, 3f);
		blackboard.preenCount++;
		// animation
		blackboard.anim.SetTrigger("preen");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.time > preenStartTime + preenTime)
		{
			// idle
			return blackboard.idleState;
		}

		return this;
	}
}
