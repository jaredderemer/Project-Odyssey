using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum optionMenu{
   Cart, Spike
   
};
public class animController : MonoBehaviour {

   public optionMenu options;
	// Use this for initialization
	void Start () {
      options = optionMenu.Cart;
	}
	
	// Update is called once per frame
	void Update () {
      if (options == optionMenu.Cart) 
      {
      }
	}
}
