using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTime : MonoBehaviour {

	// Use this for initialization
	void Start () 
   {
      // Assign end time
      globalController.Instance.startTime = Time.time;
      Debug.Log (globalController.Instance.startTime);
	}
}
