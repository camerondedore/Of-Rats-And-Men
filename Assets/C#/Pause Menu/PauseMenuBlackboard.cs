using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBlackboard : MonoBehaviour
{

	public GameObject menu;
	public StateMachine thisMachine;
	public AudioSourceController aud;
	public AudioClip clickSound;
	public Pause pauser;
	public Animator fadeAnim;
	public State pauseState,
		playState;
	public float quitDelay = 1,
		loadDelay = 1;
}
