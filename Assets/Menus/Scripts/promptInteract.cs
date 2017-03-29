using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class promptInteract : MonoBehaviour
{
   private GameObject interactPrompt;     // The prompt gameObject
   public GameObject promptTextObject;   // The prompt text gameObject
   private GameObject promptPanel;
   public string     text;               // Text to show on prompt
   
   public  Transform interactable;       // The interactable object
   private bool      interacted = false; // State of object interaction
   private Vector3   newPosition;        // The new position of the prompt
   public  float     yPosition; 			  // The height above the object for the prompt

	// Use this for initialization
	void Start ()
   {
      promptPanel = GameObject.Find("PromptPanel");
      
      
      interactPrompt = GameObject.Find("InteractPrompt");
      
      //promptPanel = interactPrompt.transform.GetChild(0).gameObject;
	}
   
   void OnTriggerEnter(Collider other)
   {
      // Check if the object has been interacted with
      if (!interacted && other.gameObject.CompareTag("Player"))
      {
         // Set prompt text
         promptTextObject.GetComponent<Text>().text = text;
         
         // Reposition the prompt above this object
         newPosition = interactable.position;
         newPosition.y += yPosition;
         Debug.Log(newPosition);
         interactPrompt.transform.position = newPosition;
         
         // Activate the prompt
         //interactPrompt.SetActive(true);
         promptPanel.SetActive(true);
      }
   }
   
   // Display the prompt if the player is near the object
   void OnTriggerStay(Collider other)
   {
      // Check if the player interacts
      if (Input.GetKey(KeyCode.E) && other.tag == "Player")
      {
         // Hide the prompt after the player interacts
         //interactPrompt.SetActive(false);
         promptPanel.SetActive(false);
         
         interacted = true;
      }
   }
   
   // Hide the prompt after the player moves away from the object
   void OnTriggerExit(Collider other)
   {
      if (!interacted && other.gameObject.CompareTag("Player"))
      {
         //interactPrompt.SetActive(false);
         promptPanel.SetActive(false);
      }
   }
}
