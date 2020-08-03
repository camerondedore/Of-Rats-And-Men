using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbs : MonoBehaviour, IPickup
{
    
	[SerializeField]
	float disinfect = 5;



	void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime, Space.World);
    }



	public void Pickup(Transform player)
	{
		Disease.disease.DecreaseInfection(disinfect);
		Destroy(gameObject);
	}
}
