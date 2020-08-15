using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenStateCall : RavenState
{
       
	float lastCallTime = -Mathf.Infinity;
	int calls = 1;


	
	public override void RunState()
	{
		if(Time.time > lastCallTime + 0.5f && calls > 0)
		{
			// audio
			blackboard.aud.PlayCall();
			// animation
			blackboard.anim.SetTrigger("call");
			calls--;
			lastCallTime = Time.time;
		}
	}



	public override void StartState()
	{
		calls = Random.Range(1, 4);
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		if(Time.time > lastCallTime + 0.5f)
		{
			if(calls <= 0)
			{
				// idle
				return blackboard.idleState;
			}
		}

		return this;
	}
}
