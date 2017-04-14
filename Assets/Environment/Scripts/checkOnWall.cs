using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkOnWall : MonoBehaviour
{
   private GameObject myPlayer;

	// Use this for initialization
	void Start ()
   {
		myPlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
   {
      Debug.Log("grounded == " + myPlayer.GetComponent<PlayerControllerTest>().grounded);
      
      if (other.tag == "Player" && myPlayer.GetComponent<PlayerControllerTest>().grounded == false)
      {
         myPlayer.GetComponent<PlayerControllerTest>().onWall = true;
      }
   }
   
   void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         myPlayer.GetComponent<PlayerControllerTest>().onWall = false;
      }
   }
}
