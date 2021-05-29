using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEat : MonoBehaviour
{
    
	Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
		// randomize animation
		anim.SetFloat("idleOffset", Random.Range(0f, 1f));
    }
}