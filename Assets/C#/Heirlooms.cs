using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class Heirlooms : MonoBehaviour
{
    
	public static List<string> collectedHeirlooms = new List<string>();



	void Awake()
	{
		LoadCollectedHeirlooms();
		// Debug.Log("collected heirlooms: ");
		// foreach(var s in collectedHeirlooms)
		// {
		// 	Debug.Log(s);
		// }
		// Debug.Log(Application.persistentDataPath);
	}



	public static void CollectHeirloom(string hierloomName)
	{
		collectedHeirlooms.Add(hierloomName);
		SaveCollectedHeirlooms();
	}



	public static void SaveCollectedHeirlooms() 
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/heirlooms.dwg");
		bf.Serialize(file, collectedHeirlooms);
		file.Close();
	}



	public static void LoadCollectedHeirlooms() 
	{
		if(File.Exists(Application.persistentDataPath + "/heirlooms.dwg")) 
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/heirlooms.dwg", FileMode.Open);
			collectedHeirlooms = (List<string>)bf.Deserialize(file);
			file.Close();
		}
	}
}
