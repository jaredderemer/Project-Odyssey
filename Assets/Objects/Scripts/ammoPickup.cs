using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour 
{
    public int ammoAmount;

	// Use this for initialization
	void Start () 
	{
       
	}
	
	// Update is called once per frame
    void Update() 
	{   
       
	}
	
	// Activates upon contact with player
    // Will call player's add health script and heal them
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<playerAttacks>().ammoPickup(ammoAmount);
            Destroy(gameObject);
        }
	}
}
