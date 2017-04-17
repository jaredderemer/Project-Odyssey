using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class promptInteract : MonoBehaviour
{
   private GameObject interactPrompt;     // The prompt gameObject
   public GameObject promptTextObject;    // The prompt text gameObject
   private GameObject promptPanel;
   private GameObject promptBtn;
   private GameObject buttonText;
   public string     text;                // Text to show on prompt
   public string     altText;             // Text to show on prompt
   public string     buttonTextString;    // Text to show on prompt button
   
   public  Transform interactable;        // The interactable object
   private bool      interacted = false;  // State of object interaction
   public  bool      disappearOnInteract = true; // Default to true
   private Vector3   newPosition;         // The new position of the prompt
   public  float     yPosition; 			   // The height above the object for the prompt
   
   public int itemIDNeeded;

	// Use this for initialization
	void Start ()
   {
      promptPanel = GameObject.Find("PromptPanel");
      promptBtn = GameObject.Find("promptButton");
      interactPrompt = GameObject.Find("InteractPrompt");
      buttonText = GameObject.Find("ButtonText");
	}
   
   void OnTriggerEnter(Collider other)
   {
      // Check if the object has been interacted with
      if (!interacted && other.gameObject.CompareTag("Player"))
      {
         // Check player inventory for needed item
         if(other.GetComponent<Inventory2>().checkInventory(itemIDNeeded) || itemIDNeeded == 0)
         {
            // Set prompt text
            promptTextObject.GetComponent<Text>().text = text;
            promptBtn.SetActive(true);
         }
         else
         {
            // Display message that they need the required item
            promptTextObject.GetComponent<Text>().text = altText;
            promptBtn.SetActive(false);
         }
         
         // Set Button Text
         if(promptBtn.activeSelf)
         {
            //if(buttonTextString == "E" || buttonTextString == "W")
            if (buttonTextString != "")
            {
               buttonText.GetComponent<Text>().text = buttonTextString;
            }
            else
            {
               // Default
               buttonText.GetComponent<Text>().text = "E";
            }
         }

         
         // Reposition the prompt above this object
         newPosition = interactable.position;
         newPosition.y += yPosition;
         interactPrompt.transform.position = newPosition;
         
         // Activate the prompt
         promptPanel.SetActive(true);
         
         Debug.Log("Hit trigger");
         
      }
   }
   
   // Display the prompt if the player is near the object
   void OnTriggerStay(Collider other)
   {
      // Check if the player interacts
      if (Input.GetKey(KeyCode.E) && other.tag == "Player" && other.GetComponent<Inventory2>().checkInventory(itemIDNeeded) ||
          Input.GetKey(KeyCode.E) && other.tag == "Player" && itemIDNeeded == 0)
      {
         
         
         // Check if we want the interact to disappear
         if(disappearOnInteract)
         {
            // Hide the prompt after the player interacts
            promptPanel.SetActive(false);
            interacted = true;
         }
         else
         {
            // Set item needed to 0 so prompt shows up to open door
            itemIDNeeded = 0;
         }
      }
   }
   
   // Hide the prompt after the player moves away from the object
   void OnTriggerExit(Collider other)
   {
      if (!interacted && other.gameObject.CompareTag("Player"))
      {
         promptPanel.SetActive(false);
      }
   }
}
