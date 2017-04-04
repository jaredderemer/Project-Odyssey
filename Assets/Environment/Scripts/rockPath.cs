using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockPath : MonoBehaviour {

   public GameObject hidden;
   public float waitTime;

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.E)) 
      {
         StartCoroutine (moveToggle ());
         StartCoroutine (makePath ());
      }
   }
    
   IEnumerator moveToggle ()
   {
      gameObject.transform.eulerAngles = new Vector3 (0f, 0f, -20f);
      yield return new WaitForSeconds (waitTime);
      gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
   }

   IEnumerator makePath ()
   {
      hidden.SetActive (true);
      yield return new WaitForSeconds (waitTime);
      hidden.SetActive (false);
   }
}
