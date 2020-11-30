using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UILayerMovement : MonoBehaviour
{
    
	[SerializeField]
	float maxDisplacement = 10,
		inputSpeed = 10;
	[SerializeField]
	UILayer[] layers;
	float x,
		y;



    void Start()
    {
        
    }

    

    void Update()
    {
        x += Input.GetAxisRaw("Mouse X") * Time.deltaTime * inputSpeed;
        y += Input.GetAxisRaw("Mouse Y") * Time.deltaTime * inputSpeed;

		x = Mathf.Clamp(x, -maxDisplacement, maxDisplacement);
		y = Mathf.Clamp(y, -maxDisplacement, maxDisplacement);

		foreach(var layer in layers)
		{
			var newPosition = new Vector3(x, y, layer.transform.position.z) * layer.displacementMultiplier;
			layer.transform.anchoredPosition = newPosition;
		}
    }



	[Serializable]
	class UILayer
	{
		public float displacementMultiplier = 1;
		public RectTransform transform;
	}
}
