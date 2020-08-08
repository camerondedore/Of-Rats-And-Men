using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DiseaseZoneVisualizerEditor : MonoBehaviour
{
    
	[SerializeField]
	Mesh boxMesh,
		sphereMesh;

    

    void Update()
    {
        if(Application.isEditor)
		{
			// get collider
			var col = transform.root.GetComponent<Collider>();
			// get mesh
			var meshFilter = GetComponent<MeshFilter>();
			
			// edit visualizer
			if(col.GetType() == typeof(BoxCollider))
			{
				// box
				var box = ((BoxCollider) col);
				meshFilter.mesh = boxMesh;
				transform.localPosition = box.center;
				transform.localScale = box.size;
			}
			else if(col.GetType() == typeof(SphereCollider))
			{
				// sphere
				var sphere = ((SphereCollider) col);
				meshFilter.mesh = sphereMesh;
				transform.localPosition = sphere.center;
				transform.localScale = Vector3.one * sphere.radius * 2;
			}
		}
    }
}
