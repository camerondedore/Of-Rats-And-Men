using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiseaseUI : MonoBehaviour
{
    
	[SerializeField]
	RectTransform diseaseBar;



    void Start()
    {	

    }

    

    void Update()
    {
        diseaseBar.localScale = new Vector2(Disease.disease.GetInfectionFraction(), diseaseBar.localScale.y);
    }
}
