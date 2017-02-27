using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut : MonoBehaviour
{
   public Transform target;
   
   public float leftEdge;
   public float rightEdge;
   public float lowerLimit;
   public float upperLimit;
 
   // Updates the coordinates the camera is focused on
   void LateUpdate ()
   {
      if (target.position.x >= leftEdge && target.position.x <= rightEdge)
      {
         transform.LookAt (target.transform);
      }
      if (target.position.y >= lowerLimit && target.position.y <= upperLimit)
      {
         Debug.Log("second if");
         transform.Translate (3.53f, target.position.y-transform.position.y, -10.28f);
      }
   }
}