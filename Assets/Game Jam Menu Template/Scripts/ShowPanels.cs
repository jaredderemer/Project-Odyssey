﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowPanels : MonoBehaviour {

	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject panelTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject creditsPanel;							//Store a reference to the Game Object CreditsPanel
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel


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
