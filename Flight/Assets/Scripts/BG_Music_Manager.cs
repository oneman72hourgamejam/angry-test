using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BG_Music_Manager : MonoBehaviour
{
	public List<AudioClip> SongList = new List<AudioClip>();
	public float bgVolume = 1.00f;
	public int curSong = 0;
	public int ranMin, ranMax;
	public bool PlayRandomly = false;
	
	void Start()
	{
		audio.volume = bgVolume;
		ranMax = SongList.Count;
	}
	
	void Update()
	{
		if(PlayRandomly)
			PlayRandom();
		else
			Playlist();
	}
	
	void PlayRandom()
	{
		if(!audio.isPlaying)
		{
			audio.clip = SongList[Random.Range(ranMin, ranMax)];
			audio.Play();
		}
	}

	void Playlist()
	{
		if(!audio.isPlaying)
		{
			if(curSong > SongList.Capacity)
			{
				curSong = 0;
			}
			else
			{
				curSong++;
			}
			audio.clip = SongList[curSong];
			audio.Play();
		}
	}
	
	void PlayRepeat(AudioClip Song)
	{
		audio.clip = Song;
		audio.loop = true;
		audio.Play();
	}

	void ChangeSpeed(float Speed)
	{
		if(Speed > 3)
			Speed = 3;

		if(Speed < -3)
			Speed = -3;

		audio.pitch = Speed;
	}
}