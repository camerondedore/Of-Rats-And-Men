using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    
	[SerializeField]
	float jumpHeight = 2,
		speed = 4;
	CharacterController agent;
	GroundChecker feet;
	Vector3 targetVelocity,
		velocity;
	float y;
	float groundResponseSpeed = 15,
		fallResponseSpeed = 5;



    void Start()
    {
        agent = GetComponent<CharacterController>();
        feet = GetComponentInChildren<GroundChecker>();
    }

    

    void FixedUpdate()
    {	
		if(feet.isGrounded && y < -1)
		{
			agent.stepOffset = 0.3f;

			if(feet.isFlat || feet.isFlatRay)
			{
				// walk
				velocity = Vector3.Lerp(velocity, targetVelocity * speed, Time.fixedDeltaTime * groundResponseSpeed);
				if(y <= 0)
				{
					y = -1;
				}
			}
			else
			{
				// slide
				velocity = Vector3.Cross(feet.checkFeet.normal, Vector3.Cross(feet.checkFeet.normal, Vector3.up)) * speed;
				y = velocity.y;
			}
		}
		else
		{
			agent.stepOffset = 0;	

			// fall
			velocity = Vector3.Lerp(velocity, targetVelocity * speed, Time.fixedDeltaTime * fallResponseSpeed);
			y += Physics.gravity.y * Time.fixedDeltaTime;
		}

		// move
        agent.Move((velocity + Vector3.up * y) * Time.fixedDeltaTime);
	}



	public void Move(Vector3 direction)
	{
		direction = transform.TransformDirection(direction).normalized;

		if(feet.isGrounded)
		{
			// walk
			targetVelocity = Vector3.ProjectOnPlane(direction, feet.checkFeet.normal);
		}
		else
		{
			// fall
			targetVelocity = direction;
		}
	}



	public void Jump()
	{
		y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
	}
}
