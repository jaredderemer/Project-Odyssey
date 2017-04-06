﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {


   private ShowPanels showPanels;
   private Pause pauseScript;
   private StartOptions startScript;
   
   [HideInInspector] public bool gameOver = false; // Boolean for game over status
   
   //public Text statsText;
   private Text statsText;
   
   private string firstName; // User's entered first name
   private string lastName;  // User's entered last name
   
   public InputField firstNameInput;
   public InputField lastNameInput;
   
   public GameObject afterSubmissionText; // Message to be displayed after player submits score
   
   void Awake()
   {
      //Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels  = GetComponent<ShowPanels> ();
      pauseScript = GetComponent<Pause> ();
   }
   
   void Update ()
   {
      // Check if tab is pressed
      if(Input.GetKeyDown (KeyCode.Tab) && firstNameInput.GetComponent<InputField>().isFocused)
      {
         // Place cursor in lastName input fields
         lastNameInput.Select();
         lastNameInput.ActivateInputField();
      }
   }
   
   public void endGame()
   {
      //Pause game
      gameOver = true;
      
      //Set time.timescale to 0, this will cause animations and physics to stop updating
      Time.timeScale = 0;
      
      // Call the ShowGameOverPanel of the ShowPanels script
      showPanels.ShowGameOverPanel ();
      
      // Set player statistics text
      statsText = GameObject.Find("valuesText").GetComponent<Text> ();
      statsText.text = "30:88\n324\n5"; // playerTime.ToString() + "\n" + monkeys.ToString() + "\n" + easterEggs.ToString;
      
      // Place cursor in firstName input fields
      firstNameInput.Select();
      firstNameInput.ActivateInputField();
   }
   
   public void submitScore()
   {
      // Testing file I/O
      firstName = GameObject.Find("firstNameText").GetComponent<Text>().text;
      lastName = GameObject.Find("lastNameText").GetComponent<Text>().text;
      
      System.IO.File.AppendAllText("\\\\csweb\\Classes\\SEI\\Castaway\\adventure.txt", firstName + " " + lastName + " 999 99 9 9999999\n");
      
      // Hide submission fields and button
      GameObject.Find("EnterName").SetActive(false);
      GameObject.Find("SubmitScore").SetActive(false);
      
      // Show message notifying the player the score was submitted
      afterSubmissionText.SetActive(true);
   }
}