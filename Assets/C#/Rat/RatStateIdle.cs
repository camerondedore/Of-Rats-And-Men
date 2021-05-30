using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateIdle : RatState
{
   
	float startTime,
		idleTime,
		cleanTime,
		cleanStartTime;




	public override void RunState()
	{
		// clean face during idle
		if(Time.time > cleanStartTime + cleanTime)
		{
			cleanStartTime = Time.time;
			cleanTime = Random.Range(2f, 4f);
			// animation
			blackboard.anim.SetTrigger("clean");
		}
	}



	public override void StartState()
	{
		startTime = Time.time;
		idleTime = Random.Range(10f, 20f);
		cleanStartTime = Time.time;
		cleanTime = Random.Range(2f, 4f);
		// animation
		blackboard.anim.SetTrigger("idle");
		blackboard.anim.SetFloat("speed", 0);
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		// run from player
		if(Vector3.Distance(transform.position, blackboard.player.position) < blackboard.fleeDistance)
		{
			return blackboard.fleeState;
		}

		// wonder
		if(Time.time > startTime + idleTime)
		{
			return blackboard.wonderState;
		}

		return this;
	}
}
