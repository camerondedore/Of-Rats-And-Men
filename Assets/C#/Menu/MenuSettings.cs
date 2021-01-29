using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{

	[SerializeField] Dropdown qualityDropDown;
	[SerializeField] Toggle ssaoToggle;
	[SerializeField] Toggle bloomToggle;
	[SerializeField] Slider sensitivitySlider;



    void Start()
    {
        // apply settings to game world
		qualityDropDown.SetValueWithoutNotify(Settings.currentSettings.quality);
		ssaoToggle.SetIsOnWithoutNotify(Settings.currentSettings.ssao);
		bloomToggle.SetIsOnWithoutNotify(Settings.currentSettings.bloom);
		sensitivitySlider.SetValueWithoutNotify(Settings.currentSettings.sensitivity);
    }



	public void ChangeSettings()
	{
		// gather new settings from UI
		Settings.currentSettings.quality = qualityDropDown.value;
		Settings.currentSettings.ssao = ssaoToggle.isOn;
		Settings.currentSettings.bloom = bloomToggle.isOn;
		Settings.currentSettings.sensitivity = sensitivitySlider.value;

		Settings.SaveSettings();
	} 
}
