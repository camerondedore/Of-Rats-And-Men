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



	void Start()
	{
		aud = GetComponentInChildren<AudioSourceController>();
	}



	public void StepEvent()
	{
		var stepSound = stepSounds[Random.Range(0, stepSounds.Length)];
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
