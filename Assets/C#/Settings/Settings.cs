using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class Settings : MonoBehaviour
{
    
	public static playerSettings currentSettings;



	void Awake()
	{
		LoadSettings();
	}



	public static void SaveSettings() 
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/settings.dwg");
		bf.Serialize(file, currentSettings);
		file.Close();
	}



	public static void LoadSettings() 
	{
		if(File.Exists(Application.persistentDataPath + "/settings.dwg")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/settings.dwg", FileMode.Open);
			currentSettings = (playerSettings)bf.Deserialize(file);
			file.Close();
		}
		else
		{
			// no settings exist
			currentSettings = new playerSettings();
			SaveSettings();
		}

		// Debug.Log(currentSettings.quality);
		// Debug.Log(currentSettings.ssao);
		// Debug.Log(currentSettings.bloom);
		// Debug.Log(currentSettings.sensitivity);
	}



	[System.Serializable]
	public class playerSettings
	{
		public int quality = 5;
		public bool ssao = true,
			bloom = true;
		public float sensitivity = 10;
	}
}
