using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class MenuSettings : MonoBehaviour
{

	[SerializeField] Dropdown qualityDropDown;
	[SerializeField] Toggle ssaoToggle;
	[SerializeField] Toggle bloomToggle;
	[SerializeField] Slider sensitivitySlider;
	[SerializeField] PostProcessProfile ppp;
	AmbientOcclusion ssao;
	Bloom bloom;



    void Start()
    {
		ppp.TryGetSettings(out ssao);
		ppp.TryGetSettings(out bloom);

        // apply settings to game world
		qualityDropDown.SetValueWithoutNotify(Settings.currentSettings.quality);
		ssaoToggle.SetIsOnWithoutNotify(Settings.currentSettings.ssao);
		bloomToggle.SetIsOnWithoutNotify(Settings.currentSettings.bloom);
		sensitivitySlider.SetValueWithoutNotify(Settings.currentSettings.sensitivity);

		QualitySettings.SetQualityLevel(Settings.currentSettings.quality);
		ssao.active = Settings.currentSettings.ssao;
		bloom.active = Settings.currentSettings.bloom;
		Look.lookSensitivity = Settings.currentSettings.sensitivity;
    }



	public void ChangeSettings()
	{
		// gather new settings from UI
		Settings.currentSettings.quality = qualityDropDown.value;
		Settings.currentSettings.ssao = ssaoToggle.isOn;
		Settings.currentSettings.bloom = bloomToggle.isOn;
		Settings.currentSettings.sensitivity = sensitivitySlider.value;

		QualitySettings.SetQualityLevel(Settings.currentSettings.quality);
		ssao.active = Settings.currentSettings.ssao;
		bloom.active = Settings.currentSettings.bloom;
		Look.lookSensitivity = Settings.currentSettings.sensitivity;

		Settings.SaveSettings();
	} 
}
