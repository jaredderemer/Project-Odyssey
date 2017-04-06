using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headSpeaker : MonoBehaviour {

   private AudioSource dingAS;
   private bool isUsed;
   private string[] messageList = new string[12]; // Array of easter puns 

	// Use this for initialization
	void Start () 
   {
      dingAS  = GetComponent<AudioSource> ();
      isUsed = false;

      // Populating array of easter puns
      messageList[0] = "Don't spell part backwards. It's a trap.";
      messageList[1] = "I relish the fact that you've mustard the strength to ketchup to me.";
      messageList[2] = "I wanna make a joke about Sodium...Na...";
      messageList[3] = "I found a rock yesterday which measured 1,760 yards in length. Must be some kind of milestone.";
      messageList[4] = "It's hard to explain puns to kleptomaniacs because they always take things literally";
      messageList[5] = "Do you know why I make puns? Because it's my respunsibility.";
      messageList[6] = "Message 7";
      messageList[7] = "Message 8";
      messageList[8] = "Message 9";
      messageList[9] = "Message 10";
      messageList[10] = "Message 11";
      messageList[11] = "Message 12";
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
