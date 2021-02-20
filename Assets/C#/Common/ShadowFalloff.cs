using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFalloff : MonoBehaviour
{
    
	[SerializeField]
	AnimationCurve falloffCurve;
	Transform mainCamera;
	Light lamp;



    void Start()
    {
		mainCamera = Camera.main.transform;
		lamp = GetComponent<Light>();
    }



    void Update()
    {
		var distaneToCamera = Vector3.Distance(transform.position, mainCamera.position);
		var falloff = falloffCurve.Evaluate(distaneToCamera);
        lamp.shadowStrength = falloff;

		if(falloff <= 0 && lamp.shadows != LightShadows.None)
		{
			lamp.shadows = LightShadows.None;
		}

		if(falloff > 0 && lamp.shadows == LightShadows.None)
		{
			lamp.shadows = LightShadows.Hard;
		}
    }
}
