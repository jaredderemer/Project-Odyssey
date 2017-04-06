using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityController : MonoBehaviour {

   public Vector3 gravity;

	void Awake () 
   {
      Physics.gravity = gravity;
	}
      public void changeGravity(float y)
   {
      Physics.gravity = new Vector3 (gravity.x, y, gravity.z);
   }
}
