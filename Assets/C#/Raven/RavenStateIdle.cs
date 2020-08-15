using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenStateIdle : RavenState
{
    
	float startTime = 0,
		idleTime = 10;
	int action = 1;


	
	public override void RunState()
	{

	}



	public override void StartState()
	{
		startTime = Time.time;
		action = Random.Range(0,4);
		idleTime = Random.Range(3f,8f);
		// animation
		blackboard.anim.SetTrigger("idle");
		blackboard.anim.SetFloat("idleOffset", Random.Range(0f, 1f));
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.time > startTime + idleTime)
		{
			if(action == 0)
			{
				// preen
				return blackboard.preenState;
			}

			// call
			return blackboard.callState;			
		}

		return this;
	}
}
