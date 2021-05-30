using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatStateWonder : RatState
{
   
	float startTime,
		wonderTime;



	public override void RunState()
	{
		// path finding
		if(Vector3.Distance(transform.root.position, blackboard.pathNodes[blackboard.targetNodeIndex].position) < 0.33f)
		{
			// get next node
			blackboard.targetNodeIndex = RatPathUtility.GetNextNode(blackboard.pathNodes, blackboard.pathDirection, blackboard.targetNodeIndex);
		}
		// get velocity
		var velocity = (blackboard.pathNodes[blackboard.targetNodeIndex].position - transform.root.position).normalized * blackboard.walkSpeed;
		// move
		blackboard.controller.velocity = velocity;

		// animation (0.33 is to normalize the speed to the animation, which is at 3 m/s)
		blackboard.anim.SetFloat("speed", blackboard.walkSpeed * 0.33f);
	}



	public override void StartState()
	{
		startTime = Time.time;
		wonderTime = Random.Range(4f, 8f);

		// get closest node
		blackboard.targetNodeIndex = RatPathUtility.GetClosestNode(blackboard.pathNodes, transform.root);
		// get direction
		blackboard.pathDirection = RatPathUtility.GetDirectionToNode(blackboard.pathNodes, transform.root, blackboard.targetNodeIndex);
		// get next node
		blackboard.targetNodeIndex = RatPathUtility.GetNextNode(blackboard.pathNodes, blackboard.pathDirection, blackboard.targetNodeIndex);
	}



	public override void EndState()
	{
		// stop
		blackboard.controller.velocity = Vector3.zero;
	}



	public override State Transition()
	{
		// run from player
		if(Vector3.Distance(transform.position, blackboard.player.position) < blackboard.fleeDistance)
		{
			return blackboard.fleeState;
		}
		
		// idle
		if(Time.time > startTime + wonderTime)
		{
			return blackboard.idleState;
		}

		return this;
	}
}

