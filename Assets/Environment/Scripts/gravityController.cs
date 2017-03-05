using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityController : MonoBehaviour {

   public Vector3 gravity;

	void Awake () 
   {
      Physics.gravity = gravity;
	}
}
