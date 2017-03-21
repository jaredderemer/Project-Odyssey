using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
   public Vector3 moving = new Vector3();

   // Use this for initialization
   void Start()
   {
      moving.x = moving.y = moving.z = 0;
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      if (Input.GetKey("right"))
      {
         moving.x = 1;
      }
      else if (Input.GetKey("left"))
      {
         moving.x = -1;
      }

      if (Input.GetKey("up"))
      {
         moving.y = 1;
      }
      else if (Input.GetKey("down"))
      {
         moving.y = -1;
      }
   }
}
