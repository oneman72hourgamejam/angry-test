using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	
	void OnGUI()
	{
		if(GetComponent<ConfigScript>().optionsGUI == false)
		{
			if(GUI.Button(new Rect(700, 400, 150, 50), "Play Game"))
				Application.LoadLevel("Chapter 10_a");
			if(GUI.Button(new Rect(700, 475, 150, 50), "Options"))
				GetComponent<ConfigScript>().optionsGUI = true;
			if(GUI.Button(new Rect(700, 550, 150, 50), "Quit Game"))
				Application.Quit();
		}
		GetComponent<ConfigScript>().OnGUI();
	}
}
