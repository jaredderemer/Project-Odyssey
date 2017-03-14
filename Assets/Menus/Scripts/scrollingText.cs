/********************************************************************** 
* Author            MM/DD/YY HH24:MM   Description                    * 
* Jared DeRemer     01/12/17 14:34     Changed return value of X() to *
**********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrollingText : MonoBehaviour {

   public Text scrollText;
   public Button creditsBack;
   public float scrollSpeed;
   Vector3 startingPosition;

   void Start ()
   {
      // Save text starting position for reset
      startingPosition = scrollText.transform.position;

      // Add listener to back button
      creditsBack.onClick.AddListener(() => ResetCredits());

   }
   
   // Update text position based on scroll speed
   void Update ()
   {
      Vector3 position = scrollText.transform.position;
      position.y += scrollSpeed;
      scrollText.transform.position = position;
   }

   // Reset credits text to desire position
   void ResetCredits ()
   {
      Vector3 position = startingPosition;
      scrollText.transform.position = position;
   }

   // Remove button listener and reset credits
   void Destroy()
   {
      creditsBack.onClick.RemoveListener(() => ResetCredits());
   }
}
