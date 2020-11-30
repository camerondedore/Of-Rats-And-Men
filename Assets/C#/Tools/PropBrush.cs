using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBrush : MonoBehaviour
{
    
	[SerializeField]
	GameObject[] props;
	[SerializeField]
	GameObject crosshair;
	[SerializeField]
	LayerMask mask;
	[SerializeField]
	float xzScaleMin,
		xzScaleMax,
		yScaleMin,
		yScaleMax,
		rotationMax;
	RaycastHit rayHit;
	List<GameObject> propsPlaced = new List<GameObject>();
	Disconnector disconnector1 = new Disconnector();
	Disconnector disconnector2 = new Disconnector();
	int propIndex;




	void Start()
	{
		propIndex = Random.Range(0, props.Length);
		crosshair.SetActive(true);
	}



	void Update()
	{
		// draw
		if (disconnector1.Trip(PlayerInput.fire1))
		{
			Physics.Raycast(transform.position, transform.forward, out rayHit, 100, mask);

			if(rayHit.collider != null)
			{
				var prop = Instantiate(props[propIndex], rayHit.point, Quaternion.identity) as GameObject;
				propsPlaced.Add(prop);
				
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
				if(props.Length > 1)
				{
					var lastPropIndex = propIndex;
					while(lastPropIndex == propIndex)
					{
						propIndex = Random.Range(0, props.Length);
					}
				}
			}
		}

		// delete
		if (disconnector2.Trip(PlayerInput.fire2) && props.Length > 0)
		{
			var propToDestroy = propsPlaced[propsPlaced.Count - 1];
			propsPlaced.Remove(propToDestroy);
			Destroy(propToDestroy);
		}
	}
}
