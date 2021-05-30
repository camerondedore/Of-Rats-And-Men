using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateFlee : RatState
{
   




	public override void RunState()
	{
		// path finding
		if(Vector3.Distance(transform.root.position, blackboard.pathNodes[blackboard.targetNodeIndex].position) < 0.33f)
		{
			// get next node
			blackboard.targetNodeIndex = RatPathUtility.GetNextNode(blackboard.pathNodes, blackboard.pathDirection, blackboard.targetNodeIndex);
		}
		// get velocity
		var velocity = (blackboard.pathNodes[blackboard.targetNodeIndex].position - transform.root.position).normalized * blackboard.runSpeed;
		// move
		blackboard.controller.velocity = velocity;

		// animation (0.33 is to normalize the speed to the animation, which is at 3 m/s)
		blackboard.anim.SetFloat("speed", blackboard.runSpeed * 0.33f);
	}



	public override void StartState()
	{
		// get closest node
		blackboard.targetNodeIndex = RatPathUtility.GetClosestNode(blackboard.pathNodes, transform.root);
		// get direction
		blackboard.pathDirection = RatPathUtility.GetDirectionToNode(blackboard.pathNodes, transform.root, blackboard.targetNodeIndex);
		// get direction to flee
		blackboard.pathDirection = RatPathUtility.GetFleeDirection(blackboard.pathNodes[blackboard.targetNodeIndex], 
			blackboard.pathDirection, 
			transform.root, 
			blackboard.player);
		// get next node
		blackboard.targetNodeIndex = RatPathUtility.GetNextNode(blackboard.pathNodes, blackboard.pathDirection, blackboard.targetNodeIndex);

		// audio
		blackboard.aud.source.volume = 1;
	}



	public override void EndState()
	{
		// stop
		blackboard.controller.velocity = Vector3.zero;

		// audio
		blackboard.aud.source.volume = 0;
	}



	public override State Transition()
	{
		// idle
		if(Vector3.Distance(transform.position, blackboard.player.position) > blackboard.fleeResetDistance)
		{
			return blackboard.idleState;
		}

		return this;
	}
}

