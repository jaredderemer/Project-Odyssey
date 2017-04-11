/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/10/17  22:25      Rotate an onject in Y axis              *
*                                                                              *
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
   {
      transform.Rotate (0, 5, 0);	
	}
}
