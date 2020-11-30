using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeLookCamera : MonoBehaviour
{

	[SerializeField]
	float lookSensitivity = 10,
		speed = 4;
	Vector2 lookAngles,
		lookRawChange;
	float lookLimit = 89;



    void Awake()
	{
		lookAngles = new Vector2(0, transform.localEulerAngles.y);
	}



    void FixedUpdate()
	{
		// apply look
		if(lookRawChange.sqrMagnitude > 0)
		{
			var lookChange = lookRawChange * lookSensitivity * Time.fixedDeltaTime;
			lookAngles += lookChange;
			lookAngles.x = Mathf.Clamp(lookAngles.x, -lookLimit, lookLimit);

			transform.localRotation = Quaternion.Euler(lookAngles);
		}
	}



	public void Update()
	{
		// get look input
		var lookInput = -PlayerInput.look;
		lookInput.y *= -1;
		lookRawChange = lookInput;

		// get move input
		var moveInput = new Vector3(PlayerInput.move.x, PlayerInput.jump, PlayerInput.move.y);
		moveInput.Normalize();

		// apply move
		transform.position += transform.TransformDirection(moveInput) * speed * Time.deltaTime;
	}
}
