using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour {


	public AudioClip song1;
	public AudioClip song2;
   public AudioClip song3;
	public AudioMixerSnapshot volumeDown;			//Reference to Audio mixer snapshot in which the master volume of main mixer is turned down
	public AudioMixerSnapshot volumeUp;				//Reference to Audio mixer snapshot in which the master volume of main mixer is turned up


	private AudioSource musicSource;				//Reference to the AudioSource which plays music
	private float resetTime = .01f;					//Very short time used to fade in near instantly without a click


	void Awake () 
	{
		//Get a component reference to the AudioSource attached to the UI game object
		musicSource = GetComponent<AudioSource> ();
		//Call the PlayLevelMusic function to start playing music
	}


	//Used if running the game in a single scene, takes an integer music source allowing you to choose a clip by number and play.
	public void PlaySelectedMusic(int musicChoice)
	{

		//This switch looks at the integer parameter musicChoice to decide which music clip to play.
		switch (musicChoice) 
		{
		//if musicChoice is 0 assigns titleMusic to audio source
		case 1:
			musicSource.clip = song1;
			break;
		case 2:
			musicSource.clip = song2;
			break;
      case 3:
			musicSource.clip = song3;
			break;
		}
		//Play the selected clip
		musicSource.Play ();
	}

	//Call this function to very quickly fade up the volume of master mixer
	public void FadeUp(float fadeTime)
	{
		//call the TransitionTo function of the audioMixerSnapshot volumeUp;
		volumeUp.TransitionTo (fadeTime);
	}

	//Call this function to fade the volume to silence over the length of fadeTime
	public void FadeDown(float fadeTime)
	{
		//call the TransitionTo function of the audioMixerSnapshot volumeDown;
		volumeDown.TransitionTo (fadeTime);
	}
}
