using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickup : MonoBehaviour 
{
    public int ammoAmount;


	// Activates upon contact with player
    // Will call player's add health script and heal them
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<playerAmmo>().ammoPickup(ammoAmount);
            Destroy(gameObject);
        }
	}
}
