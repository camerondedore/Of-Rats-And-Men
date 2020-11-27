using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heirloom : MonoBehaviour, IPickup
{
    
	[SerializeField]
	AudioClip pickupSound;
	[SerializeField]
	string heirloomName;
	AudioSource aud;



	void Start()
	{
		// check collection list
		if(Heirlooms.collectedHeirlooms.Contains(heirloomName))
		{
			Destroy(gameObject);
		}

		aud = GetComponent<AudioSource>();
	}



	void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime, Space.World);
    }



	public void Pickup(Transform player)
	{
		// save object to collection list
		Heirlooms.CollectHeirloom(heirloomName);
		// destroy
		aud.PlayOneShot(pickupSound);
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
		GetComponentInChildren<ParticleSystem>().Stop();
		Destroy(gameObject, 10);
	}
}

