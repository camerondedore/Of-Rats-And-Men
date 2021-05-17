using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWaterFX : MonoBehaviour
{

	[SerializeField]
	Transform sensor;
	[SerializeField]
	float waterLevel = -2;
	ParticleSystem fx;
	VelocityTracker vel;
	AudioSourceController aud;
	float targetVolume = 0,
		startVolume,
		volumeSpeed = 5;
	bool underWater = false;



    void Start()
    {
        fx = GetComponent<ParticleSystem>();
		aud = GetComponent<AudioSourceController>();
		vel = GetComponentInParent<VelocityTracker>();
		startVolume = aud.source.volume;
		aud.source.volume = 0;
    }



    void FixedUpdate()
    {
		transform.position = new Vector3(transform.position.x, waterLevel, transform.position.z);

       	if(!underWater && vel.speed > 0.1f && sensor.position.y <= waterLevel)
		{
			underWater = true;
			fx.Play();
			targetVolume = startVolume;
			volumeSpeed = 10;
		}
		
		if(underWater && (vel.speed <= 0.1f || sensor.position.y > waterLevel))
		{
			underWater = false;
			fx.Stop();
			targetVolume = 0;
			volumeSpeed = 3;
		}

		aud.source.volume = Mathf.Lerp(aud.source.volume, targetVolume, 5f * Time.fixedDeltaTime);
    }
}
