using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBlackboard : MonoBehaviour
{
    
	// STATES NEVER TRANSISTION TO OTHER STATES
	// NO NEED TO HAVE STATES IN BLACKBOARD
	// public State homeState,
	// 	playState,
	// 	loadState,
	// 	settingsState,
	// 	heirloomsState,
	// 	quitState;
	public GameObject levelSelectWindow,
		heirloomsWindow,
		settingsWindow;
	public StateMachine thisMachine;
	public Animator fadeAnim;
	public AudioSourceController aud;
	public AudioClip clickSound,
		playSound,
		loadSound;
	public float quitDelay = 1,
		loadDelay = 1;
}
