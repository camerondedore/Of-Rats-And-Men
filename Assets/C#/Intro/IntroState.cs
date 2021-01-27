using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroState : State
{
    [HideInInspector]
	public IntroBlackboard blackboard;



	protected void Awake()
	{
		blackboard = GetComponent<IntroBlackboard>();
	}
}
