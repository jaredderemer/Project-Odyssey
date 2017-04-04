using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headSpeaker : MonoBehaviour {

   private AudioSource dingAS;
   private bool isUsed;
   private string[] messageList = new string[5]; // Array of easter puns 

	// Use this for initialization
	void Start () 
   {
      dingAS  = GetComponent<AudioSource> ();
      isUsed = false;

      // Populating array of easter puns
      messageList[0] = "Message 1";
      messageList[1] = "Message 2";
      messageList[2] = "Message 3";
      messageList[3] = "Message 4";
      messageList[4] = "Message 5";
	}
	
	// Update is called once per frame
	void Update () 
   {
		
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.E)) 
      {
         if (!isUsed) 
         {
            dingAS.Play ();
            showMessage ();
            isUsed = true;
         }
      }
   }

   void OnTriggerExit (Collider col)
   {
      isUsed = false;
   }

   void showMessage ()
   {
      Debug.Log ("You found an Easter Egg: " + 
                 messageList[(int)Random.Range (0, messageList.Length)]);
   }
}
