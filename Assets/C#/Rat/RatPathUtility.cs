using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPathUtility : MonoBehaviour
{
    




	public static int GetClosestNode(Transform[] nodes, Transform rat)
	{
		var distance = 1000f;
		int index = 0;
		int closestIndex = 0;

		foreach(var node in nodes)
		{
			var thisDistance = Vector3.Distance(rat.position, node.position);
			if(thisDistance < distance)
			{
				distance = thisDistance;
				closestIndex = index;
			}

			index ++;
		}

		return closestIndex;
	}



	public static int GetDirectionToNode(Transform[] nodes, Transform rat, int index)
	{
		// get distance to target node
		var directionToTarget = nodes[index].position - rat.position;

		// get disance to previous node
		var directionToPrevious = nodes[GetNextNode(nodes, -1, index)].position - rat.position;

		// get disance to next node
		var directionToNext = nodes[GetNextNode(nodes, 1, index)].position - rat.position;


		if(Vector3.Angle(directionToTarget, directionToNext) < 90)
		{
			return 1;
		}

		if(Vector3.Angle(directionToTarget, directionToPrevious) < 90)
		{
			return -1;
		}

		return 1;
	}
	
	
	
	public static int GetFleeDirection(Transform targetNode, int direction, Transform rat, Transform player)
	{
		// vector from rat to player
		var dirToPlayer = player.position - rat.position;
		dirToPlayer.y = 0;

		// vector from rat to target node
		var dirToTargetNode = targetNode.position - rat.position;
		dirToTargetNode.y = 0;

		if(Vector3.Angle(dirToPlayer, dirToTargetNode) < 90)
		{
			// flee in opposite direction
			return direction * -1;
		}

		// flee in current direction
		return direction;
	}



	public static int GetNextNode(Transform[] nodes, int direction, int index)
	{
		var nextNodeIndex = index + direction;

		// loop from end
		if(nextNodeIndex >= nodes.Length)
		{
			return 0;
		}

		// loop from start
		if(nextNodeIndex < 0)
		{
			return nodes.Length - 1;
		}

		// get next node
		return nextNodeIndex;
	}
}
