using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{

	[HideInInspector]
	public AudioSource source;
	public bool realTime = true,
		randomStart = false;



	void Awake()
	{
		source = GetComponent<AudioSource>();
		if(randomStart)
		{
			source.time = Random.Range(0f, source.clip.length);
			//Debug.Log(source.time);
		}
	}



	void Update()
	{
		if(realTime)
		{
			source.pitch = Time.timeScale;
		}
	}



	public void PlayOneShot(AudioClip clip)
	{
		source.PlayOneShot(clip);
	}



	public void RandomizePitch(float radius)
	{
		source.pitch = 1 + Random.Range(-radius, radius);
	}



	public void RandomizeVolume(float radius)
	{
		source.volume = 1 + Random.Range(-radius, radius);
	}
}
