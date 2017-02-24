using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestController : MonoBehaviour {

   public GameObject key;
   Animator chestAnim;
   bool isUsed;
	// Use this for initialization
	void Start () {
      chestAnim = GetComponent<Animator> ();
      isUsed = false;
	}
	
   IEnumerator OnTriggerStay(Collider target)
   {
      if (Input.GetKey (KeyCode.E) && !isUsed && target.tag == "Player") 
      {
         chestAnim.SetTrigger ("activateChest");
         yield return new WaitForSeconds (1.0f);
         Instantiate (key, new Vector3 (137.0f, 0.65f, -1.54f), transform.rotation);
         isUsed = true;
      }
   }
}
