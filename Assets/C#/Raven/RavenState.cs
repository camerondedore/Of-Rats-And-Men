using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenState : State
{

    [HideInInspector]
	public RavenBlackboard blackboard;



	protected void Awake()
	{
		blackboard = GetComponent<RavenBlackboard>();
	}
}
