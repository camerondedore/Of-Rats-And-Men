using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseZone : MonoBehaviour
{
	
	Collider zone;



	void Start()
	{
		zone = GetComponent<Collider>();
	}


    
    void FixedUpdate()
    {
        if(!Disease.disease.inZones.Contains(this) && zone.bounds.Contains(Disease.disease.transform.position))
		{
			Disease.disease.inZones.Add(this);
		}

		if(Disease.disease.inZones.Contains(this) && !zone.bounds.Contains(Disease.disease.transform.position))
		{
			Disease.disease.inZones.Remove(this);
		}
    }
}
