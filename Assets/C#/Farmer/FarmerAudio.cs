using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerAudio : MonoBehaviour
{
    
	[SerializeField]
	AudioClip[] stepSounds,
		rakeSounds;
	[SerializeField]
	AudioClip rakeShovelSound;
	[SerializeField]
	AudioSourceController aud;
	int stepSoundIndex = 0,
		rakeSoundIndex = 0;



	void Start()
	{

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


	
	public void RakeEvent()
	{
		var oldRakeSoundIndex = rakeSoundIndex;
		while(rakeSoundIndex == oldRakeSoundIndex)
		{
			rakeSoundIndex = Random.Range(0, rakeSounds.Length);
		}

		var rakeSound = rakeSounds[rakeSoundIndex];
		aud.PlayOneShot(rakeSound);
	}



	public void ShovelEvent()
	{
		aud.PlayOneShot(rakeShovelSound);
	}
}
