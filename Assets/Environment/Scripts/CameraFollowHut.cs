using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut : MonoBehaviour
{
   public  Transform target;
 
   // Updates the coordinates the camera is focused on
   void LateUpdate ()
   {
      if (target.position.x > 2.0f && target.position.x < 5.1f)
      {
         transform.LookAt (target.transform);
      }
   }
}

//x: 17.979
//y: -8.293
//z: 0