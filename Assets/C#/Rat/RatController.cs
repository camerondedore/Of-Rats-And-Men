using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    
	public Vector3 velocity;



    void Start()
    {
        
    }



    void FixedUpdate()
    {
		if(velocity.sqrMagnitude > 0.1f)
		{
			// move
			transform.position += velocity * Time.fixedDeltaTime;
			// rotate
			transform.forward = velocity;
		}
    }
}
