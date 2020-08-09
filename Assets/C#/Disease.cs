using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : MonoBehaviour
{
    
	public static Disease disease;
	public float infection = 0,
		maxInfection = 100,
		infectionRate = 1,
		infectionZoneRate = 3;
	public List<DiseaseZone> inZones = new List<DiseaseZone>();
	[SerializeField]
	CharacterBlackboard blackboard;


    void Awake()
    {
        disease = this;
    }

   

    void Update()
    {
        if(inZones.Count <= 0)
		{
			IncreaseInfection(infectionRate * Time.deltaTime);
		}
		else
		{
			IncreaseInfection(infectionZoneRate * Time.deltaTime);
		}
    }



	public void IncreaseInfection(float amount)
	{
		infection = Mathf.Clamp(infection + amount, 0, maxInfection);

		if(infection >= maxInfection)
		{
			blackboard.machine.SetState(blackboard.dieState);
		}
	}



	public void DecreaseInfection(float amount)
	{
		infection = Mathf.Clamp(infection - amount, 0, maxInfection);
	}



	public float GetInfectionFraction()
	{
		return infection / maxInfection;
	}



	public float CalculateEffectAmount(float start)
	{
		var slope = 1/(1 - start);
		var x = GetInfectionFraction();
		return Mathf.Clamp01(
			slope * x - slope * start);
	}
}
