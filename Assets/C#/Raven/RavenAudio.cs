using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenAudio : MonoBehaviour
{

	[SerializeField]
	AudioClip[] callSounds;
	AudioSourceController aud;
	int callSoundIndex = 0;



	void Start()
	{
		aud = GetComponent<AudioSourceController>();
	}



	public void PlayCall()
	{
		var oldCallSoundIndex = callSoundIndex;
		while(callSoundIndex == oldCallSoundIndex)
		{
			callSoundIndex = Random.Range(0, callSounds.Length);
		}

		var callSound = callSounds[Random.Range(0, callSounds.Length)];
		aud.PlayOneShot(callSound);
	}
}