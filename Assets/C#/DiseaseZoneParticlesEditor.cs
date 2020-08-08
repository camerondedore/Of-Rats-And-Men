using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DiseaseZoneParticlesEditor : MonoBehaviour
{
    
	[SerializeField]
	float flyDensity = 10;	
    


    void Update()
    {
        if(Application.isEditor)
		{
			// get collider
			var col = transform.root.GetComponent<Collider>();
			// get particle system
			//var particleMain = GetComponent<ParticleSystem>().main;
			var particleShape = GetComponent<ParticleSystem>().shape;
			var particleTriggers = GetComponent<ParticleSystem>().trigger;
			var particleEmission = GetComponent<ParticleSystem>().emission;
			
			// edit particle system
			if(col.GetType() == typeof(BoxCollider))
			{
				// box
				var box = ((BoxCollider) col);
				var volume = box.size.x * box.size.y * box.size.z;
				particleShape.shapeType = ParticleSystemShapeType.Box;
				particleTriggers.SetCollider(0, box);
				//particleMain.maxParticles = Mathf.RoundToInt(flyDensity * volume);
				particleEmission.rateOverTime = flyDensity * Mathf.Sqrt(volume);
				particleShape.position = box.center;
				particleShape.scale = box.size;
			}
			else if(col.GetType() == typeof(SphereCollider))
			{
				// sphere
				var sphere = ((SphereCollider) col);
				var volume = 1.33f * Mathf.PI * Mathf.Pow(sphere.radius, 3);
				particleShape.shapeType = ParticleSystemShapeType.Sphere;
				particleTriggers.SetCollider(0, sphere);
				//particleMain.maxParticles = Mathf.RoundToInt(flyDensity * volume);
				particleEmission.rateOverTime = flyDensity * Mathf.Sqrt(volume);
				particleShape.position = sphere.center;
				particleShape.scale = Vector3.one * sphere.radius;
			}
		}
    }
}
