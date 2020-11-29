﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

	



	public static void LoadLevel(string sceneName)
	{
		SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
	}
}