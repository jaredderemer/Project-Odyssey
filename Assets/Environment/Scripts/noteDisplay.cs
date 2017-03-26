/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      03/24/17  01:35      Display the message on screen           *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class noteDisplay : MonoBehaviour {

   public void displayMessage (string msg)
   {
      gameObject.GetComponent<Text> ().text = msg;
   }
}
