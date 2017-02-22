using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is on the Health Object and calls the heal function on the player
public class healthPickup : MonoBehaviour 
{

	public float healthAmount,
               timer;

	// Use this for initialization
	void Start () 
	{
        healthAmount = 10f;
	}
	
	// Update is called once per frame
    void Update() 
	{   
       // Auto increments item timer and destroys it if it isnt picked up
        
       //timer += 1;
      // if (timer == 1000)
      // {
      //     Destroy(gameObject);
      // }

	}
	
	// Activates upon contact with player
	void OnTriggerEnter(Collider other)
	{
     if (other.gameObject.CompareTag("Player"))
     {
           other.GetComponent<playerHealth>().addHealth(healthAmount);
           Destroy(gameObject);
     }
	}
}
