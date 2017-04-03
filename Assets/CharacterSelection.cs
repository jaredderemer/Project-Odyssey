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
	
   public void selectCharacter()
   {
      // Toggle off current model
      characterList[index].SetActive(false);

      index++;
      if (index == characterList.Length) 
      {
         index = 0;
      }

      // Toggle on new model
      characterList[index].SetActive(true);

   }
	
   public void Confirm()
   {
      PlayerPrefs.SetInt ("CharacterSelected", index);
      SceneManager.LoadScene ("scene2");
   }
}
