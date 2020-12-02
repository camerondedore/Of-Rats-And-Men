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
	public Animator fadeAnim;
	public float quitDelay = 1,
		loadDelay = 1;
}
