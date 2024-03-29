﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateDie : CharacterState
{

	float restartDelay = 4.1f,
		deathTime = Mathf.Infinity;
	bool animated = false;



	public override void RunState()
	{
		// clear velocity
		blackboard.velocity = Vector3.zero;
		// apply acceleration due to gravity
		blackboard.y -= Mathf.Abs(Physics.gravity.y) * Time.fixedDeltaTime;	
		blackboard.y = Mathf.Clamp(blackboard.y , -10, 100);
		// move
		blackboard.agent.Move((Physics.gravity.normalized * -blackboard.y) * Time.fixedDeltaTime);

		// die animation when grounded
		if(blackboard.feet.isGrounded && !animated)
		{						
			// grounded
			animated = true;
			blackboard.anim.SetTrigger("die");
			// vomit fx
			blackboard.vomit.Play();	
			// die audio
			blackboard.charAud.PlayDie();	
			// get death time
			deathTime = Time.time;	
		}

		if(deathTime + restartDelay < Time.time)
		{
			SceneLoader.RestartLevel();
		}
	}



	public override void StartState()
	{
		// enable steps
		blackboard.agent.stepOffset = blackboard.stepHeight;
		// anim
		blackboard.anim.ResetTrigger("jump");
	}



	public override void EndState()
	{

	}



	public override State Transition()
	{
		return this;
	}
}
