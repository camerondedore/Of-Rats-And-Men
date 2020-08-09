using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
   
    public LayerMask mask;
	public RaycastHit checkFeet,
		checkHead;
    public bool isGroundedRay,
		isGrounded,
		isFlatRay,
		isFlat,
		headBump;
	float distance,
		rayDistance,
		radius,
		maxAngle, 
		angle;
	RaycastHit checkRay;



	void Start()
	{
		var controller = transform.root.GetComponent<CharacterController>();
		
		// get radius
		radius = controller.radius;
		// get distance for sphere cast
		distance = controller.height * 0.5f - radius + controller.skinWidth + 0.01f;
		// get distance for ray cast
		rayDistance = controller.height * 0.5f + controller.stepOffset + controller.skinWidth + 0.01f;
		// get angle
		maxAngle = controller.slopeLimit;
	}



	void FixedUpdate()
	{
		Physics.SphereCast(transform.position, radius, Physics.gravity, out checkFeet, distance, mask);
		isGrounded = checkFeet.collider != null;
		isFlat = isGrounded && Vector3.Angle(Vector3.up, checkFeet.normal) < maxAngle;
		
		Physics.Raycast(transform.position, Physics.gravity, out checkRay, rayDistance, mask);
		isGroundedRay = checkRay.collider != null;
		isFlatRay = isGroundedRay && Vector3.Angle(Vector3.up, checkRay.normal) < maxAngle;

		Physics.SphereCast(transform.position, radius, -Physics.gravity, out checkHead, distance, mask);
		headBump = checkHead.collider != null && Vector3.Angle(Vector3.up, checkHead.normal) > 90;
	}
}
