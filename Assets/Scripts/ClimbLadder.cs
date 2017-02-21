using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
   public Transform CameraView;
    
   void LateUpdate ()
   {
      // While the player is positioned in front of the ladder and pressing W
      if (transform.position.x < -16.5f && transform.position.x > -17.5f &&
          transform.position.y > -1f && transform.position.y < 12f && Input.GetKey("q"))
      {
         transform.Translate(Vector3.up * 0.1f, Space.World);
         Debug.Log("Climbing");
      }
      else if (transform.position.x < -16f && transform.position.x > -18f)
      {
         // Display "W" key prompt
      }
   }
}