using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        look.y = Input.GetAxisRaw("Mouse X");
        look.x = Input.GetAxisRaw("Mouse Y");
        jump = Input.GetAxisRaw("Jump");
		//fire = Input.GetAxisRaw("Fire1");
		//aim = Input.GetAxisRaw("Fire2");
		//reload = Input.GetAxisRaw("Reload");
		pause = Input.GetAxisRaw("Pause");
    }
}
