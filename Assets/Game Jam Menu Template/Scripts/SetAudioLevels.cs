using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {

	public AudioMixer mainMixer;					//Used to hold a reference to the AudioMixer mainMixer
	public Slider musicSlider;

	void Start()
	{
		SetMusicLevel (PlayerPrefs.GetFloat ("musicVol"));
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
		// Find which settings menu to set
		if (GameObject.Find ("MusicVolSliderOptions"))
		{
			musicSlider = GameObject.Find ("MusicVolSliderOptions").GetComponent <Slider> ();
			musicSlider.value = PlayerPrefs.GetFloat ("musicVol");
		}
		else if(GameObject.Find ("MusicVolSlider"))
		{
			musicSlider = GameObject.Find ("MusicVolSlider").GetComponent <Slider> ();
			musicSlider.value = PlayerPrefs.GetFloat ("musicVol");
		}
	}



	//Call this function and pass in the float parameter sfxLevel to set the volume of the AudioMixerGroup SoundFx in mainMixer
	public void SetSfxLevel(float sfxLevel)
	{
		mainMixer.SetFloat("sfxVol", sfxLevel);
		PlayerPrefs.SetFloat("sfxVol", sfxLevel);
		SetMusicSlider (sfxLevel);
	}

	//Set the Music slider position
	public void SetSfxSlider(float sfxLevel)
	{
		// Find which settings menu to set
		if (GameObject.Find ("MusicSfxSliderOptions"))
		{
			musicSlider = GameObject.Find ("MusicVolSliderOptions").GetComponent <Slider> ();
			musicSlider.value = PlayerPrefs.GetFloat ("musicVol");
		}
		else if(GameObject.Find ("SfxVolSlider"))
		{
			musicSlider = GameObject.Find ("SfxVolSlider").GetComponent <Slider> ();
			musicSlider.value = PlayerPrefs.GetFloat ("sfxVol");
		}
	}
}
