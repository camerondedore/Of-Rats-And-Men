using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{

	[SerializeField] Dropdown resolutionDropDown;
	[SerializeField] Dropdown qualityDropDown;
	[SerializeField] Toggle ssaoToggle;
	[SerializeField] Toggle bloomToggle;
	[SerializeField] Slider sensitivitySlider;
	[SerializeField] Toggle fullscreenToggle;



    void Start()
    {
        // apply settings to game world
		qualityDropDown.SetValueWithoutNotify(Settings.currentSettings.quality);
		ssaoToggle.SetIsOnWithoutNotify(Settings.currentSettings.ssao);
		bloomToggle.SetIsOnWithoutNotify(Settings.currentSettings.bloom);
		sensitivitySlider.SetValueWithoutNotify(Settings.currentSettings.sensitivity);
		fullscreenToggle.SetIsOnWithoutNotify(Settings.currentSettings.fullscreen);

		// get resolutions to populate drop down
		var text = Screen.currentResolution.width + " x " + Screen.currentResolution.height;
		resolutionDropDown.AddOptions(new List<Dropdown.OptionData> {new Dropdown.OptionData(text)});
		// set resolution drop down
		resolutionDropDown.SetValueWithoutNotify(0);
    }



	public void ChangeSettings()
	{
		// gather new settings from UI
		Settings.currentSettings.quality = qualityDropDown.value;
		Settings.currentSettings.ssao = ssaoToggle.isOn;
		Settings.currentSettings.bloom = bloomToggle.isOn;
		Settings.currentSettings.sensitivity = sensitivitySlider.value;
		Settings.currentSettings.fullscreen = fullscreenToggle.isOn;

		Settings.SaveSettings();
	} 
}
