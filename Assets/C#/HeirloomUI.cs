using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeirloomUI : MonoBehaviour
{

	[SerializeField]
	Animator heirloomFlashAnim;
	int oldHeirloomCount;


    void Start()
    {
        oldHeirloomCount = Heirlooms.collectedHeirlooms.Count;
    }



    void Update()
    {
        // heirloom collect audio
		if(oldHeirloomCount < Heirlooms.collectedHeirlooms.Count)
		{
			heirloomFlashAnim.SetTrigger("flash");		
		}		
		oldHeirloomCount = Heirlooms.collectedHeirlooms.Count;
    }
}
