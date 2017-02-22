using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowHut : MonoBehaviour
{
   public Transform target;
   
   
   // Updates the coordinates the camera is focused on
   void LateUpdate ()
   {
      if (target.position.x < -4.9f && target.position.x > -12.9f)
      {
         transform.LookAt (target.transform);
      }
   }
}

//x: -4.9269787
//y: -0.00868765
//z: -2.831221