using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateFall : CharacterState
{
    




	public override void RunState()
	{
		if(blackboard.feet.headBump && blackboard.y > 0)
		{
			blackboard.y = 0;
		}

		// get input
		blackboard.targetVelocity = blackboard.cameraControl.TransformDirection(blackboard.input.moveDirection).normalized;
		// smooth velocity to target velocity
		blackboard.velocity = Vector3.Lerp(blackboard.velocity, blackboard.targetVelocity * blackboard.speed, Time.fixedDeltaTime * blackboard.fallResponseSpeed);
		// apply acceleration due to gravity
		blackboard.y -= Mathf.Abs(Physics.gravity.y) * Time.fixedDeltaTime;
		// move
		blackboard.agent.Move((blackboard.velocity + Physics.gravity.normalized * -blackboard.y) * Time.fixedDeltaTime);
		// look
		if(blackboard.targetVelocity.sqrMagnitude > 0.1f)
		{
			blackboard.lookDirection = blackboard.targetVelocity;
			blackboard.lookDirection.y = 0;
		}
		blackboard.character.forward = Vector3.Slerp(blackboard.character.forward, blackboard.lookDirection, Time.fixedDeltaTime * 15);

		// animate
		blackboard.anim.SetFloat("y", blackboard.y);
	}



	public override void StartState()
	{
		// disable steps
		blackboard.agent.stepOffset = 0;
		// animate
		blackboard.anim.SetTrigger("fall");
	}



	public override void EndState()
	{
		// sound
		blackboard.charAud.PlayLand();
		// animate
		blackboard.anim.SetTrigger("jump");
		blackboard.anim.ResetTrigger("fall");
	}



	public override State Transition()
	{
		if(blackboard.feet.isGrounded && blackboard.y < 0)
		{
			if(!blackboard.feet.isFlat && !blackboard.feet.isFlatRay)
			{
				// slide
				return blackboard.slideState;
			}
						
			// grounded
			return blackboard.groundedState;			
		}

		return this;
	}
}
