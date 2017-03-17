using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightColorController : MonoBehaviour {
   private Light caveLight;

	// Use this for initialization
	void Start () 
   {
      caveLight = GetComponent<Light> ();	
	}
	
	// Update is called once per frame
   public void changeColor (float r, float g, float b) {
      caveLight.color = new Color (r, g, b, 255.0f);
	}
}
