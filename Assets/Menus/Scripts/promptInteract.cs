using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class promptInteract : MonoBehaviour
{
   private GameObject interactPrompt;     // The prompt gameObject
   public GameObject promptTextObject;   // The prompt text gameObject
   private GameObject promptPanel;
   private GameObject promptBtn;
   public string     text;               // Text to show on prompt
   public string     altText;               // Text to show on prompt
   
   public  Transform interactable;       // The interactable object
   private bool      interacted = false; // State of object interaction
   private Vector3   newPosition;        // The new position of the prompt
   public  float     yPosition; 			  // The height above the object for the prompt
   
   public int itemIDNeeded;

	// Use this for initialization
	void Start ()
   {
      promptPanel = GameObject.Find("PromptPanel");
      promptBtn = GameObject.Find("promptButton");
      interactPrompt = GameObject.Find("InteractPrompt");
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
         // Hide the prompt after the player interacts
         promptPanel.SetActive(false);
         
         interacted = true;
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
