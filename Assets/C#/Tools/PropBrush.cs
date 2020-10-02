using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBrush : MonoBehaviour
{
    
	[SerializeField]
	GameObject[] props;
	[SerializeField]
	LayerMask mask;
	[SerializeField]
	float xzScaleMin,
		xzScaleMax,
		yScaleMin,
		yScaleMax,
		rotationMax;
	RaycastHit rayHit;
	GameObject lastPropPlaced;
	int propIndex;



	void Start()
	{
		propIndex = Random.Range(0, props.Length);
	}



	void Update()
	{
		// draw
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Physics.Raycast(transform.position, transform.forward, out rayHit, 100, mask);

			if(rayHit.collider != null)
			{
				var prop = Instantiate(props[propIndex], rayHit.point, Quaternion.identity) as GameObject;
				lastPropPlaced = prop;
				
				// apply scale
				var xzScale = Random.Range(xzScaleMin, xzScaleMax);
				var yScale = Random.Range(yScaleMin, yScaleMax);
				prop.transform.localScale = new Vector3(xzScale, yScale, xzScale);

				// apply rotation
				var xRot = Random.Range(-rotationMax, rotationMax);
				var zRot = Random.Range(-rotationMax, rotationMax);
				var yRot = Random.Range(0f, 359f);
				prop.transform.rotation = Quaternion.Euler(new Vector3(xRot, yRot, zRot));

				// get new prop
				var lastPropIndex = propIndex;
				while(lastPropIndex == propIndex)
				{
					propIndex = Random.Range(0, props.Length);
				}
			}
		}

		// delete
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			Destroy(lastPropPlaced);
		}
	}
}
