using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuState : State
{

	[HideInInspector]
	public PauseMenuBlackboard blackboard;



	protected void Awake()
	{
		blackboard = GetComponent<PauseMenuBlackboard>();
	}
}