using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    
	public static Vector2 move,
		look;
	public static float fire,
		//aim,
		//reload,
		pause,
		jump;



    void Update()
    {
		// DEPRECATED
        // move.x = Input.GetAxisRaw("Horizontal");
        // move.y = Input.GetAxisRaw("Vertical");
        // look.y = Input.GetAxisRaw("Mouse X");
        // look.x = Input.GetAxisRaw("Mouse Y");
        // jump = Input.GetAxisRaw("Jump");
		//fire = Input.GetAxisRaw("Fire1");
		//aim = Input.GetAxisRaw("Fire2");
		//reload = Input.GetAxisRaw("Reload");
		//pause = Input.GetAxisRaw("Pause");
    }



	public void OnMove(InputValue value)
	{
		move = value.Get<Vector2>();
	}



	public void OnLook(InputValue value)
	{
		var input = value.Get<Vector2>();
		look = new Vector2(input.y, input.x);
	}



	public void OnJump(InputValue value)
	{
		jump = value.Get<float>();
	}



	public void OnPause(InputValue value)
	{
		pause = value.Get<float>();
	}
}
