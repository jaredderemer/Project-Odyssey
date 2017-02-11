using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour {

	public int healthAmount,
               timer;

	// Use this for initialization
	void Start () 
	{
       
	}
	
	// Update is called once per frame
    void Update() 
	{   
       // Auto increments item timer and destroys it if it isnt picked up
       
       //timer += 1;
       if (timer == 1000)
       {
           Destroy(gameObject);
       }

	}
	
	// Activates upon contact with player
	void onTriggerEnter(Collider other)
	{
	   
       if (other.gameObject.CompareTag("Player"))
       {
           // other.gameObject.SetActive(false);
       }
	}
}
