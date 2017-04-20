using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class profanityFilter : MonoBehaviour
{
   private ShowPanels showPanels;				  //Reference to the ShowPanels script used to hide and show UI panels
   private GameOver gameOverScript;            // Reference to GameOver script
	[HideInInspector] public bool panelVisible; //Boolean to check if the panel is visible
	
	//Awake is called before Start()
	void Awake()
	{
      panelVisible = false;
      
		//Get a component reference to ShowPanels attached to this object, store in showPanels variable
		showPanels = GetComponent<ShowPanels> ();
      
      // Get a component reference to GameOver attached to this object, store in gameOverScript variable
      gameOverScript = GetComponent<GameOver> ();
	}
   
   void Update()
   {
      if (panelVisible && Input.GetKey(KeyCode.P)) 
		{
			showPanels.HideProfanityPanel ();
         panelVisible = false;
		} 
   }
   
    // Checks a name to see if it has any inappropriate words within it
    public bool passesFilter(string name)
    {
       Debug.Log("Checking profanity on: " + name);
       
        bool     passesFilter = true;
        string   nextFilterWord;
        StreamReader stream = new StreamReader("filter.txt", Encoding.Default);

        using (stream)
        {
            while (passesFilter && (nextFilterWord = stream.ReadLine()) != null)
            {
               if (Regex.IsMatch(name, nextFilterWord))
               {
                  showPanels.ShowProfanityPanel ();
                  panelVisible = true;
                  
                  print("BAD WORD FOUND!!");
                  passesFilter = false;
               }
            }
       }
       stream.Close();
       return passesFilter;
    }
    
    
}
