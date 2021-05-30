using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatState : State
{

    [HideInInspector]
	public RatBlackboard blackboard;



	protected void Awake()
	{
		blackboard = GetComponent<RatBlackboard>();
	}
}
