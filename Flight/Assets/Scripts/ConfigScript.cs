using UnityEngine;
using System.Collections;
using System;
public class ConfigScript : MonoBehaviour {
	
	float volBG, volSFX, volATM, fov;
	public bool aa, shadows, sync, optionsGUI, full, fullscreen;
	int res;
	string settings, audiotype;
	public Rect optionsRect = new Rect(100, 100, 500, 500);
	void Start()
	{
		volBG = 0;
		volATM = 0.3f;
		volSFX = 0.8f;
		fov = 90.00f;
		aa = true;
		fullscreen = true;
		shadows = true;
		optionsGUI = true;
		LoadAll();
	}
	public void OnGUI()
	{
		if(optionsGUI)
		{
			optionsRect = GUI.Window(0, optionsRect, OptionsGUI, "Options");
		}
	}
	public void OptionsGUI(int gui)
	{
		GUILayout.BeginArea(new Rect(0, 50, 800, 800));
		GUI.Label(new Rect(25, 0, 100, 30), "Quality Settings");
		if(GUI.Button(new Rect(25, 20, 75, 20), "High"))
			GetComponent<Video_Config>().SetResolution(0, 3);
		if(GUI.Button(new Rect(100, 20, 75, 20), "Medium"))
			GetComponent<Video_Config>().SetResolution(1, 3);
		if(GUI.Button(new Rect(175, 20, 75, 20), "Low"))
			GetComponent<Video_Config>().SetResolution(2, 3);
		if(GUI.Button(new Rect(250, 20, 75, 20), "Custom"))
			GetComponent<Video_Config>().SetResolution(3, 3);
		GUI.Label(new Rect(25, 40, 100, 30), "Field of View");
		fov = GUI.HorizontalSlider(new Rect(115, 45, 100, 30), fov, 60.00f, 120.00f);
		GUI.Label(new Rect(25, 60, 100, 30), "Antialiasing");
		aa = GUI.Toggle(new Rect(115, 60, 100, 30), aa, " On/Off");
		GUI.Label(new Rect(25, 75, 100, 30), "Resolution");
		if(GUI.Button(new Rect(25, 95, 75, 20), "1920x1080"))
			GetComponent<Video_Config>().SetResolution(0, 3);
		if(GUI.Button(new Rect(100, 95, 75, 20), "1600x900"))
			GetComponent<Video_Config>().SetResolution(1, 3);
		if(GUI.Button(new Rect(175, 95, 75, 20), "1280x1024"))
			GetComponent<Video_Config>().SetResolution(2, 3);
		if(GUI.Button(new Rect(250, 95, 75, 20), "1280x800"))
			GetComponent<Video_Config>().SetResolution(3, 3);
		if(GUI.Button(new Rect(325, 95, 75, 20), "640x400"))
			GetComponent<Video_Config>().SetResolution(4, 3);
		GUI.Label(new Rect(25, 125, 100, 30), "FullScreen");
		full = GUI.Toggle(new Rect(95, 125, 100, 30), fullscreen, " On/Off");
		GUI.Label(new Rect(25, 140, 100, 30), "Shadows");
		shadows = GUI.Toggle(new Rect(95, 140, 100, 30), shadows, " On/Off");
		GUI.Label(new Rect(25, 160, 150, 30), "Music Volume");
		volBG = GUI.HorizontalSlider(new Rect(25, 180, 100, 30), volBG,
		                             0.00f, 1.00f);
		GUI.Label(new Rect(25, 200, 150, 30), "SFX Volume");
		volSFX = GUI.HorizontalSlider(new Rect(25, 220, 100, 30), volSFX,
		                              0.00f, 1.00f);
		GUI.Label(new Rect(25, 240, 150, 30), "Atmospheric Volume");
		volATM = GUI.HorizontalSlider(new Rect(25, 260, 100, 30), volATM, 0.00f, 1.00f);
		GUI.Label(new Rect(25, 270, 100, 30), "Speaker Type");
		if(GUI.Button(new Rect(25, 290, 75, 20), "Mono"))
			GetComponent<Audio_Config>().SetAudioType("Mono");
		if(GUI.Button(new Rect(100, 290, 75, 20), "Stereo"))
			GetComponent<Audio_Config>().SetAudioType("Stereo");
		if(GUI.Button(new Rect(175, 290, 75, 20), "Surround"))
			GetComponent<Audio_Config>().SetAudioType("Surround");
		if(GUI.Button(new Rect(250, 290, 100, 20), "Surround 5.1"))
			GetComponent<Audio_Config>().SetAudioType("Surround 5.1");
		if(GUI.Button(new Rect(350, 290, 100, 20), "Surround 7.1"))
			GetComponent<Audio_Config>().SetAudioType("Surround 7.1");
		if(GUI.Button(new Rect(25, 350, 100, 20), "Save Settings"))
			SaveAll();
		GUI.Button(new Rect(150, 350, 100, 20), "Back");
		GUILayout.EndArea();
	}
	void SaveAll()
	{
		PlayerPrefs.SetString("Custom_Settings", settings);
		if(shadows)
			PlayerPrefs.SetInt("Custom_Shadows", 1);
		else
			PlayerPrefs.SetInt("Custom_Shadows", 0);
		PlayerPrefs.SetFloat("Custom_FOV", fov);
		PlayerPrefs.SetInt("Custom_Resolution", res);
		PlayerPrefs.SetInt("Custom_Full", Convert.ToInt32(fullscreen));
		if(aa)
			PlayerPrefs.SetInt("Custom_AA", 1);
		else
			PlayerPrefs.SetInt("Custom_AA", 0);
		if(sync)
			PlayerPrefs.SetInt("Custom_Sync", 1);
		else
			PlayerPrefs.SetInt("Custom_Sync", 0);
		PlayerPrefs.SetFloat("atmVolume", volBG);
		PlayerPrefs.SetFloat("sfxVolume", volSFX);
		PlayerPrefs.SetFloat("bgVolume", volATM);
		PlayerPrefs.SetString("audioType", audiotype);
	}
	void LoadAll()
	{
		volBG = PlayerPrefs.GetFloat("bgVolume");
		volSFX = PlayerPrefs.GetFloat("sfxVolume");
		volATM = PlayerPrefs.GetFloat("atmVolume");
		fov = PlayerPrefs.GetFloat("Custom_FOV");
		aa = Convert.ToBoolean(PlayerPrefs.GetInt("Custom_AA"));
		shadows = Convert.ToBoolean(PlayerPrefs.GetInt("Custom_Shadows"));
		sync = Convert.ToBoolean(PlayerPrefs.GetInt("Custom_Sync"));
		fullscreen = Convert.ToBoolean(PlayerPrefs.GetInt("Custom_Full"));
		res = PlayerPrefs.GetInt("Custom_Resolution");
		settings = PlayerPrefs.GetString("Custom_Settings");
		audiotype = PlayerPrefs.GetString("audioType");
	}
}
