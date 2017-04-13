using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headSpeaker : MonoBehaviour {

   public GameObject promptText;
   private AudioSource dingAS;
   private bool isUsed;
   private string[] messageList = new string[6]; // Array of easter puns 

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
	}

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.E)) 
      {
         if (!isUsed) 
         {
            dingAS.Play ();
            StartCoroutine (showMessage ());
            isUsed = true;
         }
      }
   }

   void OnTriggerExit (Collider col)
   {
      isUsed = false;
   }

   IEnumerator showMessage ()
   {
      int index = (int)Random.Range (0, messageList.Length);
      promptText.GetComponent<Text>().text = messageList[index];
      yield return new WaitForSeconds (3.0f);
      promptText.GetComponent<Text>().text = "";
   }
}
