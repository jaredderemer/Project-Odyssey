using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {
   
   public Transform lift; // Manipulated when key is triggered
   public float length;   // Length required to move up lift
   public float speed;    // Speed required to move up lift

   private float min;
   private float max;
   private Vector3 newPos;
   private bool isClicked;

//   private float degrees;
//   Vector3 rotateObj;
//   void Start()
//   {
//      degrees = 120.0f;
//      rotateObj = new Vector3 (0, 0, degrees);
//   }
//
//   void Update()
//   {
//      transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, rotateObj, Time.deltaTime); 
//   }

   void Start () {
      min  = lift.position.y;
      max       = lift.position.y + length;
      isClicked = false;
   }

   void OnTriggerEnter(Collider collider)
   {
      if (collider.tag == "Player") // NOTE: CHANGE TO WEAPON WHEN COCONUTS ARE READY
      {
         isClicked = true;
      }
   }

   void Update()
   {
      
      if (isClicked) 
      {
         StartCoroutine (animateTile());
      }
   }

   IEnumerator animateTile()
   {
      newPos = updateNewPosition (max);
      lift.position = Vector3.Lerp (lift.position, newPos, speed * Time.deltaTime);
      yield return new WaitForSeconds (5.0f);
      newPos = updateNewPosition (min);
      lift.position = Vector3.Lerp (lift.position, newPos, speed * Time.deltaTime);
      isClicked = false;
   }

   Vector3 updateNewPosition(float newY)
   {
      return (new Vector3(lift.position.x, newY, lift.position.z));
   }
}
