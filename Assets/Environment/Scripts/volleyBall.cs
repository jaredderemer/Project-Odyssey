using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volleyBall : MonoBehaviour {

   public Transform volleyball;
   public GameObject wilson;
   public Vector3 position;

   private bool isUsed;

	// Use this for initialization
	void Start () 
   {
      isUsed = false;	
	}

   IEnumerator OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey(KeyCode.E) && !isUsed) 
      {
         // Instantiate a volleyball
         Instantiate (volleyball, position, volleyball.rotation);

         wilson.SetActive(true);

         // Increment easter egg counter
         globalController.Instance.easterEggCounter += 1;

         isUsed = true;

         yield return new WaitForSeconds (5.0f);
         Destroy (GameObject.Find("volleyball(Clone)"));
         Destroy (wilson);
      }
   }
}
