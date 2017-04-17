using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTime : MonoBehaviour {

	// Use this for initialization
	void Start () 
   {
      // Assign end time
      globalController.Instance.startTime = System.DateTime.Now.ToString ("HH:mm:ss");
      Debug.Log (globalController.Instance.startTime);
	}
}
