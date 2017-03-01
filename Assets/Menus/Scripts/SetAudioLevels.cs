using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

	public AudioMixer mainMixer;					//Used to hold a reference to the AudioMixer mainMixer
	public Slider musicSlider;
	public Slider sfxSlider;

	void Start()
	{
		SetMusicLevel (PlayerPrefs.GetFloat ("musicVol"));
		SetSfxLevel (PlayerPrefs.GetFloat ("sfxVol"));
	}

	//Call this function and pass in the float parameter musicLvl to set the volume of the AudioMixerGroup Music in mainMixer
	public void SetMusicLevel(float musicLvl)
	{
		mainMixer.SetFloat("musicVol", musicLvl);
		PlayerPrefs.SetFloat("musicVol", musicLvl);
		SetMusicSlider (musicLvl);
	}

	//Set the Music slider position
	public void SetMusicSlider(float musicLvl)
	{
      musicSlider.value = PlayerPrefs.GetFloat ("musicVol");
	}

	//Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
	public void SetSfxLevel(float sfxLevel)
	{
		mainMixer.SetFloat("sfxVol", sfxLevel);
		PlayerPrefs.SetFloat("sfxVol", sfxLevel);
		SetSfxSlider (sfxLevel);
	}

	//Set the Sound effects slider position
	public void SetSfxSlider(float sfxLevel)
	{
      sfxSlider.value = PlayerPrefs.GetFloat ("sfxVol");
	}
}
