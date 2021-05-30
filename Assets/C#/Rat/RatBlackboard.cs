using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBlackboard : MonoBehaviour
{
    
	public State idleState,
		fleeState,
		wonderState;
	public Transform player;
	public float fleeDistance = 5,
		fleeResetDistance = 15,
		speed = 3;
	public Animator anim;
	public Transform[] pathNodes;
	public int targetNodeIndex;
	public int pathDirection = 1;
}
