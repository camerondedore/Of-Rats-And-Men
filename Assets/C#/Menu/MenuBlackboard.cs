using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBlackboard : MonoBehaviour
{
    
	public State homeState,
		playState,
		loadState,
		settingsState,
		heirloomsState,
		quitState;
	public GameObject levelSelectWindow,
		heirloomsWindow,
		settingsWindow;
	public float quitDelay = 1,
		loadDelay = 1;
}
