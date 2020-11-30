using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{

    public static Vector2 look;



	public void OnMouse(InputValue value)
	{
		look = value.Get<Vector2>();
	}
}
