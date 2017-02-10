using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

	public float percentageLoaded = 0;
	private int loadingCounter = 0;
	public Text progressText;
	public string levelName;
	AsyncOperation async;

	// Print on a guiText how much has been streamed level at index 1
	// When finished streaming, print "Level 1 has been fully streamed!"
	public void Start()
	{
		levelName = "scene1";
		StartCoroutine ("load");

		progressText = GameObject.Find("LoadingText").GetComponent<Text>();

	}

	public void Update()
	{

		if(loadingCounter < 100)
		{
			//percentageLoaded = async.progress * 100 ;
			progressText.text = loadingCounter + "%";
			loadingCounter++;
		}
		else
		{
			progressText.text = loadingCounter + "%";
			async.allowSceneActivation = true;
		}
	}

	IEnumerator load()
	{
		Debug.Log ("async load started");
		async = SceneManager.LoadSceneAsync (levelName);
		async.allowSceneActivation = false;

		yield return async;
	}

	public void ActivateScene()
	{
		async.allowSceneActivation = true;
	}
}
