using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkOnWall : MonoBehaviour
{
   private GameObject myPlayer;

	// Use this for initialization
	void Start ()
   {
		myPlayer = GameObject.Find("Fisherman");
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
   {
      Debug.Log("grounded == " + myPlayer.GetComponent<playerController>().grounded);
      
      if (other.tag == "Player" && myPlayer.GetComponent<playerController>().grounded == false)
      {
         myPlayer.GetComponent<playerController>().onWall = true;
      }
   }
   
   void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player")
      {
         myPlayer.GetComponent<playerController>().onWall = false;
      }
   }
}
