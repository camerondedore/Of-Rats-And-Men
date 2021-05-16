using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
    
	[SerializeField]
	Vector3 bobAmplitude,
		bobPhase,
		bobSpeed;
	[SerializeField]
	float noiseSpeed,
		noiseSize;
	Vector3 startPosition,
		startAngles;


    void Start()
    {
        startPosition = transform.position;
		startAngles = transform.eulerAngles;
    }

   

    void FixedUpdate()
    {
		var bobChangeX = (Mathf.Sin(Time.time * bobSpeed.x) + bobPhase.x) * bobAmplitude.x;
		var bobChangeY = (Mathf.Sin(Time.time * bobSpeed.y) + bobPhase.y) * bobAmplitude.y;
		var bobChangeZ = (Mathf.Sin(Time.time * bobSpeed.z) + bobPhase.z) * bobAmplitude.z;
		var bobChange = new Vector3(bobChangeX, bobChangeY, bobChangeZ);

        transform.position = startPosition + bobChange;


		var noiseChangeX = Mathf.PerlinNoise(Time.time * noiseSpeed, 1) - 0.5f;
		var noiseChangeY = Mathf.PerlinNoise(Time.time * noiseSpeed, 10) - 0.5f;
		var noiseChangeZ = Mathf.PerlinNoise(Time.time * noiseSpeed, 20) - 0.5f;
		var noiseChange = new Vector3(noiseChangeX, noiseChangeY, noiseChangeZ) * noiseSize;

		transform.rotation = Quaternion.Euler(startAngles + noiseChange);
    }
}
