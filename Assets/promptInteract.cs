using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class promptInteract : MonoBehaviour
{
   private GameObject interactPrompt; // The prompt gameObject
   public Transform interactable;     // The interactable object
   private bool interacted = false;   // State of object interaction
   private Vector3 newPosition;       // The new position of the prompt

	// Use this for initialization
	void Start ()
   {
      interactPrompt = GameObject.Find("InteractPrompt");
      interactPrompt.SetActive(true);
	}
   
   void OnTriggerEnter(Collider other)
   {
      // Check if the object has been interacted with
      if (!interacted && other.gameObject.CompareTag("Player"))
      {
         // Reposition the prompt above this object
         newPosition = interactable.position;
         newPosition.y += 3.3f;
         Debug.Log(newPosition);
         interactPrompt.transform.position = newPosition;
         
         // Ativate the prompt
         interactPrompt.SetActive(true);
      }
   }
   
   void OnTriggerStay(Collider other)
   {
      if (Input.GetKey(KeyCode.E) && other.tag == "Player")
      {
         interactPrompt.SetActive(false);
         interacted = true;
      }
   }
   
   void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         interactPrompt.SetActive(false);
      }
   }
}
