using UnityEngine;
using System.Collections;
using System;
public class VideoConfigScript : MonoBehaviour {
	
	public void SetDefaults()
	{
		SetSettings("Medium");
		ToggleShadows(1);
		SetFOV(90.00f);
		SetResolution(0, 1);
		SetAA(2);
		SetVsync(1);
	}
	
	public void ToggleShadows(int newToggle)
	{
		Light[] lights = GameObject.FindObjectsOfType<Light>();
		foreach(Light light in lights)
		{
			if(newToggle == 0)
				light.shadows = LightShadows.None;
			else
				light.shadows = LightShadows.Hard;
		}
	}
	
	public void SetFOV(float newFOV)
	{
		Camera.main.fieldOfView = newFOV;
	}
	
	public void SetResolution(int Res, int Full)
	{
		bool fs = Convert.ToBoolean(Full);
		switch(Res)
		{
		case 0:
			Screen.SetResolution(1920, 1080, fs);
			break;
		case 1:
			Screen.SetResolution(1600, 900, fs);
			break;
		case 2:
			Screen.SetResolution(1280, 1024, fs);
			break;
		case 3:
			Screen.SetResolution(1280, 800, fs);
			break;
		case 4:
			Screen.SetResolution(640, 400, fs);
			break;
		}
	}
	
	public void SetAA(int Samples)
	{
		if(Samples == 0 || Samples == 2 || Samples == 4 || Samples == 8)
			QualitySettings.antiAliasing = Samples;
	}
	
	public void SetVsync(int Sync)
	{
		QualitySettings.vSyncCount = Sync;
	}
	
	public void SetSettings(string Name)
	{
		switch(Name)
		{
		case "Low":
			QualitySettings.SetQualityLevel(0);
			break;
		case "Medium":
			QualitySettings.SetQualityLevel(1);
			break;
		case "High":
			QualitySettings.SetQualityLevel(2);
			break;
		}
	}
	
	public void LoadAll()
	{
		SetSettings(PlayerPrefs.GetString("Custom_Settings"));
		ToggleShadows(PlayerPrefs.GetInt("Custom_Shadows"));
		SetFOV(PlayerPrefs.GetFloat("Custom_FOV"));
		SetResolution(PlayerPrefs.GetInt("Custom_Resolution"), PlayerPrefs.GetInt("Custom_Full"));
		SetAA(PlayerPrefs.GetInt("Custom_AA"));
		SetVsync(PlayerPrefs.GetInt("Custom_Sync"));
	}
}
