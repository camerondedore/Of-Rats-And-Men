using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArrow : MonoBehaviour
{

	[SerializeField]
	Vector3 direction;
	[SerializeField]
	float speed = 1;
    Vector3 startPosition,
		worldDirction;



    void Start()
    {
        startPosition = transform.position;
		worldDirction = transform.TransformDirection(direction);
    }

    

    void FixedUpdate()
    {
        transform.position = startPosition + worldDirction * Mathf.Sin(Time.time * 2 * Mathf.PI);
    }
}
