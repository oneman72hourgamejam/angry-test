using UnityEngine;
using System.Collections;

public class AudioconfigScript : MonoBehaviour {
	
	public void SetDefaults()
	{
		SetBG(1.00f);
		SetSFX(0.80f);
		SetAtm(0.60f);
		SetAudioType("Stereo");
	}
	public void SetBG(float bgVolume)
	{
		AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();
		foreach(AudioSource source in audios)
		{
			source.volume = bgVolume;
		}
	}
	public void SetSFX(float sfxVolume)
	{
		AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();
		foreach(AudioSource source in audios)
		{
			source.volume = sfxVolume;
		}
	}
	public void SetAtm(float atmVolume)
	{
		AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();
		foreach(AudioSource source in audios)
		{
			source.volume = atmVolume;
		}
	}
	public void SetAudioType(string SpeakerMode)
	{
		switch(SpeakerMode)
		{
		case "Mono":
			AudioSettings.speakerMode = AudioSpeakerMode.Mono;
			break;
		case "Stereo":
			AudioSettings.speakerMode = AudioSpeakerMode.Stereo;
			break;
		case "Surround":
			AudioSettings.speakerMode = AudioSpeakerMode.Surround;
			break;
		case "Surround 5.1":
			AudioSettings.speakerMode = AudioSpeakerMode.Mode5point1;
			break;
		case "Surround 7.1":
			AudioSettings.speakerMode = AudioSpeakerMode.Mode7point1;
			break;
		}
	}
}
