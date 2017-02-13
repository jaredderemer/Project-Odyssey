using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour {
    int timer;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += 1;
        if (timer == 1000)
        {
            Destroy(gameObject);
        }
	}
}
