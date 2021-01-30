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
	Image veinImage;
	[SerializeField]
	Animator herbFlashAnim,
		deathFadeAnim;
	[SerializeField]
	AudioSourceController aud;
	[SerializeField]
	AudioClip deathSound;
	float veinInfectionStart = 0.33f,
		oldInfection = 0;
	bool inZones = false,
		dead = false;



    void Start()
    {	

    }

    

    void Update()
    {
		if(Time.timeScale <= 0 || Disease.disease == null)
		{
			return;
		}

		// meter ui
        diseaseBar.localScale = new Vector2(Disease.disease.GetInfectionFraction(), diseaseBar.localScale.y);

		// flies
		if(Disease.disease.inZones.Count > 0 && !inZones)
		{
			inZones = true;
			// play
			diseaseZoneFlies.Play();
		}
		
		if(Disease.disease.inZones.Count < 1 && inZones)
		{
			inZones = false;
			// stop
			diseaseZoneFlies.Stop();
		}

		// vein ui
		var newVeinColor = Color.white;
		newVeinColor.a = Disease.disease.CalculateEffectAmount(veinInfectionStart);
		veinImage.color = newVeinColor;

		// herb flash ui
		if(oldInfection > Disease.disease.infection)
		{
			herbFlashAnim.SetTrigger("flash");
		}		

		// die
		if(!dead && Disease.disease.infection >= 100)
		{
			dead = true;
			aud.PlayOneShot(deathSound);
			deathFadeAnim.SetTrigger("die");
		}

		oldInfection = Disease.disease.infection;
    }
}
