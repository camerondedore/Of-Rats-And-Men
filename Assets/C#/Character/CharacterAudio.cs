using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    
	public AudioClip[] stepSounds;
	public AudioClip slideSound,
		jumpSound,
		landSound;
	AudioSourceController aud;
	int stepSoundIndex = 0;



	void Start()
	{
		aud = GetComponentInChildren<AudioSourceController>();
	}



	public void StepEvent()
	{
		var oldStepSoundIndex = stepSoundIndex;
		while(stepSoundIndex == oldStepSoundIndex)
		{
			stepSoundIndex = Random.Range(0, stepSounds.Length);
		}

		var stepSound = stepSounds[stepSoundIndex];
		aud.PlayOneShot(stepSound);
	}



	public void SlideStart()
	{
		aud.source.pitch = 1;
		aud.source.clip = slideSound;
		aud.source.Play();
	}



	public void SlideStop()
	{
		aud.source.clip = null;
		aud.source.Stop();
	}



	public void PlayJump()
	{
		aud.source.pitch = 1;
		aud.PlayOneShot(jumpSound);
	}



	public void PlayLand()
	{
		aud.source.pitch = 1;
		aud.PlayOneShot(landSound);
	}
}
