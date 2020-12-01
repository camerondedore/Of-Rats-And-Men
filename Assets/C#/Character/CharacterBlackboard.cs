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
	[HideInInspector]
	public float y;
	[HideInInspector]
	public Vector3 targetVelocity,
		velocity,
		lookDirection;
}
