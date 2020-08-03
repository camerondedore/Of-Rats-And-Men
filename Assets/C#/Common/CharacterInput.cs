using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    
    public Vector3 moveDirection;
	public float jump;



    void Update()
    {	
		moveDirection = new Vector3(PlayerInput.move.x, 0, PlayerInput.move.y);
		jump = PlayerInput.jump;
    }



	void OnDisable()
	{
		moveDirection = Vector3.zero;
		jump = 0;
	}
}
