using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockPath : MonoBehaviour {

   public GameObject hidden;
   public float waitTime;
   private Vector3 orgPosition;
   private Vector3 newPosition;
   private bool isTriggered;

   void Start ()
   {
      isTriggered = false;
      orgPosition = transform.position;
      newPosition = new Vector3 (transform.position.x, 11.9f, transform.position.z);
   }

   void OnTriggerEnter (Collider collider)
   {
      if (collider.tag == "Player")
      {
         isTriggered = true;
      }
   }

   void OnTriggerStay (Collider col)
   {
      if (col.tag == "Player" && Input.GetKey (KeyCode.E)) 
      {
         //isTriggered = true;
         StartCoroutine (moveToggle ());
         StartCoroutine (makePath ());
      }
   }

   void Update ()
   {
      if (isTriggered) 
      {
         //StartCoroutine (moveToggle ());
      }
   }

   IEnumerator moveToggle ()
   {
      Debug.Log ("here");

      //gameObject.transform.eulerAngles = new Vector3 (120.0f, 90.0f, 0f);
      transform.position = Vector3.Lerp(orgPosition, newPosition, 5f*Time.deltaTime);
      yield return new WaitForSeconds (5.0f);
      //gameObject.transform.eulerAngles = new Vector3 (60.0f, 90.0f, 0f);
      transform.position = Vector3.Lerp(newPosition, orgPosition, 5f);
      isTriggered = false;
   }

   IEnumerator makePath ()
   {
      hidden.SetActive (true);
      yield return new WaitForSeconds (waitTime);
      hidden.SetActive (false);
   }
}
