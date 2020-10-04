using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heirloom : MonoBehaviour, IPickup
{
    
	[SerializeField]
	string heirloomName;



	void Start()
	{
		// check collection list
		if(Heirlooms.collectedHeirlooms.Contains(heirloomName))
		{
			Destroy(gameObject);
		}
	}



	void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime, Space.World);
    }



	public void Pickup(Transform player)
	{
		// save object to collection list
		Heirlooms.CollectHeirloom(heirloomName);
		Destroy(gameObject);
	}
}

