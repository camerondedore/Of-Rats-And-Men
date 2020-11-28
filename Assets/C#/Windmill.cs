using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    
	float speed = 3;



    void Start()
    {
		speed = Random.Range(3f, 10f);
        transform.Rotate(0, 0, Random.Range(0f, 359f));
    }

    

    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.fixedDeltaTime);
    }
}
