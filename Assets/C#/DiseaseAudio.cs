using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseAudio : MonoBehaviour
{
    
	[SerializeField]
	AudioSourceController diseaseZoneFliesAud,
		infectionDroneAud,
		infectionBeatAud,
		inhaleAud;
	float fliesAudTargetVolume = 0,
		infectionDroneStart = 0.5f,
		infectionBeatStart = 0.66f,
		oldInfection = 0;
	bool inZones = false;



    void Start()
    {
		diseaseZoneFliesAud.source.time = Random.Range(5f, 20f);
    }


    
    void Update()
    {
		if(Time.timeScale <= 0 || Disease.disease == null)
		{
			return;
		}

        // flies
		if(Disease.disease.inZones.Count > 0 && !inZones)
		{
			inZones = true;
			// play
			fliesAudTargetVolume = 1;
		}
		
		if(Disease.disease.inZones.Count < 1 && inZones)
		{
			inZones = false;
			// stop
			fliesAudTargetVolume = 0;
		}

		// smooth flies audio
		diseaseZoneFliesAud.source.volume = Mathf.MoveTowards(diseaseZoneFliesAud.source.volume, fliesAudTargetVolume, Time.deltaTime * 2);

		// infection drone audio
		infectionDroneAud.source.volume = Mathf.MoveTowards(infectionDroneAud.source.volume,
			Disease.disease.CalculateEffectAmount(infectionDroneStart), Time.deltaTime * 2);

		// infection beat audio
		infectionBeatAud.source.volume = Mathf.MoveTowards(infectionBeatAud.source.volume, 
			Disease.disease.CalculateEffectAmount(infectionBeatStart), Time.deltaTime * 2);
		if(Disease.disease.infection >= Disease.disease.maxInfection)
		{
			// dead, stop beat
			infectionBeatAud.source.volume = 0;
		}

		// herb inhale audio
		if(oldInfection > Disease.disease.infection)
		{
			inhaleAud.source.Play();
		}		
		oldInfection = Disease.disease.infection;
    }
}
