using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateSlide : CharacterState
{
    
	float clearTimeStart = 0;
	bool clear = false;



	public override void RunState()
	{
		// get and set sliding velocity
		if(blackboard.feet.isGrounded){
			blackboard.velocity = Vector3.Cross(blackboard.feet.checkFeet.normal, Vector3.Cross(blackboard.feet.checkFeet.normal, -Physics.gravity.normalized)) * blackboard.speed;
		}
		// move
		blackboard.agent.Move((blackboard.velocity) * Time.fixedDeltaTime);
		// look
		if(blackboard.velocity.sqrMagnitude > 0.1f)
		{
			blackboard.lookDirection = blackboard.velocity;
			blackboard.lookDirection.y = 0;
		}
		blackboard.character.forward = Vector3.Slerp(blackboard.character.forward, blackboard.lookDirection, Time.fixedDeltaTime * 15);

		// clear ledge timer
		if(!clear && !blackboard.feet.isGrounded)
		{
			clear = true;
			clearTimeStart = Time.time;
			// dust
			blackboard.feetDust.Stop();
		}
	}



	public override void StartState()
	{
		clear = false;
		clearTimeStart = Time.time;
		// animate
		blackboard.anim.SetTrigger("slide");
		// dust
		blackboard.feetDust.Play();
	}



	public override void EndState()
	{
		// dust
		blackboard.feetDust.Stop();
	}



	public override State Transition()
	{
		if(blackboard.feet.isGrounded || Time.time < clearTimeStart + 0.1f)
		{
			if(blackboard.feet.isFlat && blackboard.feet.isFlatRay)
			{
				// grounded
				return blackboard.groundedState;
			}

			return this;
		}
		else
		{
			// fall
			return blackboard.fallState;
		}
	}
}
