﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateGrounded : CharacterState
{





	public override void RunState()
	{
		// get input
		var moveDir = blackboard.cameraControl.TransformDirection(blackboard.input.moveDirection).normalized;
		// project input on ground
		if(blackboard.feet.isFlat)
		{
			// grounded
			blackboard.targetVelocity = Vector3.ProjectOnPlane(moveDir, blackboard.feet.checkFeet.normal).normalized;
		}
		else if(blackboard.feet.isFlatRay)
		{
			// ray grounded 
			blackboard.targetVelocity = Vector3.ProjectOnPlane(moveDir, blackboard.feet.checkFeetRay.normal).normalized;
		}
		// smooth velocity to target velocity
		blackboard.velocity = Vector3.Lerp(blackboard.velocity, blackboard.targetVelocity * blackboard.speed, Time.fixedDeltaTime * blackboard.groundResponseSpeed);
		// set constant downward velocity
		blackboard.y = 1f;		
		// move
		blackboard.agent.Move((blackboard.velocity + Physics.gravity.normalized * blackboard.y) * Time.fixedDeltaTime);
		// look
		if(blackboard.targetVelocity.sqrMagnitude > 0.1f)
		{
			blackboard.lookDirection = blackboard.targetVelocity;
			blackboard.lookDirection.y = 0;
		}
		blackboard.character.forward = Vector3.Slerp(blackboard.character.forward, blackboard.lookDirection, Time.fixedDeltaTime * 15);
		// get real speed
		var realSpeed = blackboard.tracker.velocity.magnitude;
		// animate
		blackboard.anim.SetFloat("speed", realSpeed);
		if(realSpeed > 0.01f)
		{
			// run
			blackboard.anim.SetFloat("timeScale", realSpeed / blackboard.speed);
		}
		else
		{
			// idle
			blackboard.anim.SetFloat("timeScale", 1);
		}
	}



	public override void StartState()
	{
		// enable steps
		blackboard.agent.stepOffset = blackboard.stepHeight;
		// animate
		blackboard.anim.SetTrigger("grounded");
	}



	public override void EndState()
	{
		
	}



	public override State Transition()
	{
		if((blackboard.feet.isGrounded || blackboard.feet.isGroundedRay) && blackboard.feet.angle < blackboard.maxSlope)
		{
			if(blackboard.input.jump > 0 && (blackboard.feet.isFlat || blackboard.feet.isFlatRay))
			{
				// jump
				return blackboard.jumpState;
			}

			if(!blackboard.feet.isFlat && !blackboard.feet.isFlatRay)
			{
				// slide
				return blackboard.slideState;
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
