using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseUI : MonoBehaviour
{
    
	[SerializeField]
	RectTransform diseaseBar;
	[SerializeField]
	ParticleSystem diseaseZoneFlies;
	[SerializeField]
	AudioSourceController diseaseZoneFliesAud;
	float fliesAudTargetVolume = 0;
	bool inZones = false;



    void Start()
    {	

    }

    

    void Update()
    {
		if(Time.timeScale <= 0)
		{
			return;
		}

		// meter
        diseaseBar.localScale = new Vector2(Disease.disease.GetInfectionFraction(), diseaseBar.localScale.y);

		// flies
		if(Disease.disease.inZones.Count > 0 && !inZones)
		{
			inZones = true;
			// play
			diseaseZoneFlies.Play();
			fliesAudTargetVolume = 1;
		}
		
		if(Disease.disease.inZones.Count < 1 && inZones)
		{
			inZones = false;
			// stop
			diseaseZoneFlies.Stop();
			fliesAudTargetVolume = 0;
		}

		// smooth flies audio
		diseaseZoneFliesAud.source.volume = Mathf.MoveTowards(diseaseZoneFliesAud.source.volume, fliesAudTargetVolume, Time.deltaTime * 2);
    }
}
