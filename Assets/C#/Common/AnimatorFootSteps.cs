using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFootSteps : MonoBehaviour
{
    
	public AudioClip stepSound,
		slideSound;
	public float randomPitch = 0.3f;
	AudioSourceController aud;



	void Start()
	{
		aud = GetComponentInChildren<AudioSourceController>();
	}



	public void StepEvent()
	{
		aud.RandomizePitch(randomPitch);
		aud.PlayOneShot(stepSound);
	}



	public void SlideStart()
	{
		aud.source.clip = slideSound;
		aud.source.Play();
	}



	public void SlideStop()
	{
		aud.source.clip = null;
		aud.source.Stop();
	}
}
