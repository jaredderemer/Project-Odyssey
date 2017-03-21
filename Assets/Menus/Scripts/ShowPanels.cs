using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowPanels : MonoBehaviour
{
	public GameObject controlsPanel;						//Store a reference to the Game Object ControlsPanel
	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject creditsPanel;							//Store a reference to the Game Object CreditsPanel
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel
	public GameObject panelTint;							//Store a reference to the Game Object OptionsTint 
   
   private Pause pauseScript;						//Reference to the PauseScript script

   void Awake()
	{
		//Get a reference to Pause attached to UI object
		pauseScript = GetComponent<Pause> ();
	}
   
	//Call this function to activate and display the Control panel during the main menu
	public void ShowControlsPanel()
	{
		controlsPanel.SetActive(true);
		panelTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Control panel during the main menu
	public void HideControlsPanel()
	{
		controlsPanel.SetActive(false);
		panelTint.SetActive(false);

		// Check if game is still paused
      if(pauseScript.isPaused)
      {
         ShowPausePanel();
      }
	}

	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		panelTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		panelTint.SetActive(false);
	}

	//Call this function to activate and display the Credits panel during the main menu
	public void ShowCreditsPanel()
	{
		creditsPanel.SetActive(true);
		panelTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Credits panel during the main menu
	public void HideCreditsPanel()
	{
		creditsPanel.SetActive(false);
		panelTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
		menuPanel.SetActive (true);
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
		pausePanel.SetActive (true);
		panelTint.SetActive(true);
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		panelTint.SetActive(false);
	}
}