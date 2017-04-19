using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{


   private ShowPanels showPanels;
   private Pause pauseScript;
   private StartOptions startScript;
   private profanityFilter profanityChecker;
   
   [HideInInspector] public bool gameOver = false; // Boolean for game over status

   //public Text statsText;
   private Text statsText;
   private Text statsLabels;
   
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
      profanityChecker = GameObject.Find("UI").GetComponent<profanityFilter>();
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
      

      // Set stats label
      if(globalController.Instance.gameMode == 2)
      {
         statsLabels = GameObject.Find("statsText").GetComponent<Text> ();
         statsLabels.text = "Total Score:\nTime:\nMonkeys Eliminated:\nRounds:";
      }
    
      // Set player statistics text
      statsText = GameObject.Find("valuesText").GetComponent<Text> ();

      fillStats (globalController.Instance.gameMode);

      // playerTime.ToString() + "\n" + monkeys.ToString() + "\n" + easterEggs.ToString;
      
      // Place cursor in firstName input fields
      firstNameInput.Select();
      firstNameInput.ActivateInputField();
   }

   public void fillStats (int mode)
   {
      // Format time
      float totalTime = (globalController.Instance.endTime - globalController.Instance.startTime);
      string minutes = Mathf.Floor(totalTime / 60).ToString("00");
      string seconds = (totalTime % 60).ToString("00");
      string formattedTime = minutes + ":" + seconds;

      switch (mode) 
      {
         case 1:
            statsText.text = globalController.Instance.playerScore.ToString () + "\n" +
            formattedTime + "\n" +
            globalController.Instance.monkeysKilled.ToString () + "\n" +
            globalController.Instance.easterEggCounter.ToString (); 
            break;
         case 2:
            statsText.text = globalController.Instance.playerScore.ToString () + "\n" +
            formattedTime + "\n" +
            globalController.Instance.monkeysKilled.ToString () + "\n" +
            globalController.Instance.easterEggCounter.ToString () +
            globalController.Instance.rounds.ToString ();
            break;
      }
   }
   public void submitScore()
   {
      // IF tests to see if the input is valid and acceptible for submission
      if(true) // NICHOLAS!! INSERT FUNCTION HERE
      {
         // Testing file I/O
         firstName = GameObject.Find("firstNameText").GetComponent<Text>().text;
         lastName = GameObject.Find("lastNameText").GetComponent<Text>().text;

         // DEBUG TEST
         firstName = firstName.ToUpper();
         lastName  = lastName.ToUpper();
         print(firstName + lastName);
      
         //System.IO.File.AppendAllText("\\\\csweb\\Classes\\SEI\\Castaway\\adventure.txt", firstName + " " + lastName + " 999 99 9 9999999\n");
         
         int totalTime = (int)(globalController.Instance.endTime - globalController.Instance.startTime);
         
        //TEST for bad words
         if (profanityChecker.passesFilter(firstName) && profanityChecker.passesFilter(lastName))
          {
             // Adventure Mode
             if(globalController.Instance.gameMode == 1)
             {
               System.IO.File.AppendAllText("\\\\csweb\\Classes\\SEI\\Castaway\\adventure.txt",
              
                firstName + " " + 
                lastName + " " +
                totalTime.ToString() + " " +
                globalController.Instance.monkeysKilled.ToString() + " " +
                globalController.Instance.easterEggCounter.ToString() + " " +
                globalController.Instance.playerScore.ToString() + "\n");
             }
             // Horde Mode
             else if(globalController.Instance.gameMode == 2)
             {
                // Put file path here
               System.IO.File.AppendAllText("\\\\csweb\\Classes\\SEI\\Castaway\\horde.txt",
              
                firstName + " " + 
                lastName + " " +
                totalTime.ToString() + " " +
                globalController.Instance.monkeysKilled.ToString() + " " +
                globalController.Instance.playerScore.ToString() + "\n");
             }
          }
          else
          {
            Debug.Log("bad words found");
          }

         // Hide submission fields and button
         GameObject.Find("EnterName").SetActive(false);
         GameObject.Find("SubmitScore").SetActive(false);
      
         // Show message notifying the player the score was submitted
         afterSubmissionText.SetActive(true);
      }
      else
      {
         // Do this action if the name was not appropriate.
         
      }   
      
   }
}
