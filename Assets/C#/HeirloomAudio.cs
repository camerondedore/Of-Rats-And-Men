using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeirloomAudio : MonoBehaviour
{

	[SerializeField]
	AudioSourceController heirloomAud;
	int oldHeirloomCount;



    void Start()
    {
		oldHeirloomCount = Heirlooms.collectedHeirlooms.Count;
    }



    void Update()
    {
        // heirloom collect audio
		if(oldHeirloomCount < Heirlooms.collectedHeirlooms.Count)
		{
			heirloomAud.source.Play();
		}		
		oldHeirloomCount = Heirlooms.collectedHeirlooms.Count;
    }
}
