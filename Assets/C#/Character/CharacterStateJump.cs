using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateJump : CharacterState
{
   
	float tics = 0;



	public override void RunState()
	{
		// get input
		var moveDir = blackboard.cameraControl.TransformDirection(blackboard.input.moveDirection).normalized;
		// project input on ground
		blackboard.targetVelocity = Vector3.ProjectOnPlane(moveDir, blackboard.feet.checkFeet.normal);
		// smooth velocity to target velocity
		blackboard.velocity = Vector3.Lerp(blackboard.velocity, blackboard.targetVelocity * blackboard.speed, Time.fixedDeltaTime * blackboard.groundResponseSpeed);
		// set constant downward velocity
		blackboard.y = -1;		
		// move
		blackboard.agent.Move((blackboard.velocity + Physics.gravity.normalized * -blackboard.y) * Time.fixedDeltaTime);
		// look
		if(blackboard.targetVelocity.sqrMagnitude > 0.1f)
		{
			blackboard.lookDirection = blackboard.targetVelocity;
			blackboard.lookDirection.y = 0;
		}
		blackboard.character.forward = Vector3.Slerp(blackboard.character.forward, blackboard.lookDirection, Time.fixedDeltaTime * 15);
		// run tic
		tics--;
	}



	public override void StartState()
	{
		// animate
		blackboard.anim.SetTrigger("jump");
		// set tics
		tics = 4;
		// sound
		blackboard.charAud.PlayJump();
	}



	public override void EndState()
	{
		// set vertical speed
		blackboard.y = Mathf.Sqrt(blackboard.jumpHeight * -2f * Physics.gravity.y);
	}



	public override State Transition()
	{
		if(tics <= 0)
		{
			// fall
			return blackboard.fallState;
		}

		return this;
	}
}
