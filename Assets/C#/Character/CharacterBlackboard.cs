using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBlackboard : MonoBehaviour
{

	public StateMachine machine;
	public State groundedState,
		fallState,
		jumpState,
		slideState,
		dieState;
	public CharacterController agent;
	public CharacterInput input;
	public GroundChecker feet;
	public Animator anim;
	public VelocityTracker tracker;
	public ParticleSystem feetDust,
		fallDust,
		vomit;
	public CharacterAudio charAud;
	public Transform character,
		cameraControl;
	public float speed = 6,
		jumpHeight = 2,
		groundResponseSpeed = 15,
		fallResponseSpeed = 5,
		stepHeight = 0.3f,
		maxSlope = 80;
		// this maxSlope is for checking if falling should turn into sliding, where as the ground checker maxAngle is for being grounded
	[HideInInspector]
	public float y,
		fallDustHeight = 4;
	[HideInInspector]
	public Vector3 targetVelocity,
		velocity,
		lookDirection;
	[HideInInspector]
	public Disconnector jumpDisconnector = new Disconnector();
}
