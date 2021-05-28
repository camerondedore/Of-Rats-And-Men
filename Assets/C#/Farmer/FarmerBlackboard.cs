using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerBlackboard : MonoBehaviour
{
    
	public State idleState,
		scoopState,
		wipeState;
	public Animator anim;
	public float lastWipeTime = 0,
		wipeTime = 10;
}
