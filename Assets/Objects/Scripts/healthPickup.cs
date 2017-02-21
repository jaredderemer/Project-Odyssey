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
       
      

	}
	
	// Activates upon contact with player
    // Will call player's add health script and heal them
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<playerHealth>().addHealth(healthAmount);
            Destroy(gameObject);
        }
	}
}
