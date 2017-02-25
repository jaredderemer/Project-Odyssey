using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut : MonoBehaviour
{
   public Transform target;
   
   public float leftEdge;
   public float rightEdge;
 
   // Updates the coordinates the camera is focused on
   void LateUpdate ()
   {
      if (target.position.x > leftEdge && target.position.x < rightEdge)
      {
         transform.LookAt (target.transform);
      }
   }
}

//x: 2.0f
//y: 5.1f
//z: 0