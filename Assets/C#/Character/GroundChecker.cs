using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
   
	public float distance = 1f,
		rayDistance = 1f,
		radius = 0.2f,
		maxAngle = 30;
    public LayerMask mask;
	public RaycastHit checkFeet,
		checkHead;
    public bool isGroundedRay,
		isGrounded,
		isFlatRay,
		isFlat,
		headBump;
	float angle;
	RaycastHit checkRay;



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
