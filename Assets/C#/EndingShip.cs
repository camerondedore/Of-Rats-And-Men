using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingShip : MonoBehaviour
{
   
	[SerializeField]
	Vector3 velocity;
	[SerializeField]
	float noiseSpeed,
		noiseSize;
	Vector3 startAngles;


    void Start()
    {
		startAngles = transform.eulerAngles;
    }

   

    void FixedUpdate()
    {
        transform.position += velocity * Time.fixedDeltaTime;

		var noiseChangeX = Mathf.PerlinNoise(Time.time * noiseSpeed, 1) - 0.5f;
		var noiseChangeY = Mathf.PerlinNoise(Time.time * noiseSpeed, 10) - 0.5f;
		var noiseChangeZ = Mathf.PerlinNoise(Time.time * noiseSpeed, 20) - 0.5f;
		var noiseChange = new Vector3(noiseChangeX, noiseChangeY, noiseChangeZ) * noiseSize;

		transform.rotation = Quaternion.Euler(startAngles + noiseChange);
    }
}
