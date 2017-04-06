/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/05/17  15:30      Attach character with a certain outfit  *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

   private GameObject[] characterList;
   private int index;

	// Use this for initialization
	void Start () 
   {
      index = PlayerPrefs.GetInt ("CharacterSelected");
      characterList = new GameObject[transform.childCount];

      Debug.Log (transform.childCount);

      // Fill array with models
      for (int i = 0; i < transform.childCount; i++) 
      {
         characterList [i] = transform.GetChild (i).gameObject;
      }

      // Deactivate gameobject
      foreach (GameObject go in characterList) 
      {
         go.SetActive (false);
      }

      // Activate selected index
      if (characterList [index]) 
      {
         characterList [index].SetActive (true);
      } 
	}
	
   public void selectCharacter(int newIndex)
   {
      // Toggle off current model
      characterList[index].SetActive(false);

      // Toggle on new model
      index = newIndex;
      characterList[index].SetActive(true);
      PlayerPrefs.SetInt ("CharacterSelected", index);
   }
}
