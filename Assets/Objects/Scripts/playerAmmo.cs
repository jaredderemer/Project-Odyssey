using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAmmo : MonoBehaviour 
{

    public int coconuts; // Coconut ammo count

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void ammoPickup(int ammoCount)
    {
        if (coconuts < 99)
        {
            coconuts += ammoCount;
            
            // Update HUD
            GameObject.Find("coconutAmount").GetComponent<Text>().text = coconuts.ToString();
        }
    }
}
