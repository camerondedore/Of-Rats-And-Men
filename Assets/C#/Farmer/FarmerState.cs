using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerState : State
{
    
	[HideInInspector]
	public FarmerBlackboard blackboard;



	protected void Awake()
	{
		blackboard = GetComponent<FarmerBlackboard>();
	}
}
