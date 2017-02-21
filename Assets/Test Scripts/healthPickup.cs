﻿/********************************************************************** 
* Author            MM/DD/YY HH24:MM   Description                    * 
* Nicholas Oliver   02/05/17 23:05     Created script to handle adding*
*									   health to player when colliding* 
*									   with banana                    * 
*									   								  *
* Jared DeRemer     02/21/17 11:40     Made some small formatting 	  *
*									   changes      				  * 
**********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : MonoBehaviour 
{

	public int healthAmount;
    public Rigidbody healthText;

	// Triggers when an object collides with a banana object
	void OnTriggerEnter(Collider other)
	{
		// Check if event was triggered by the Player object
        if (other.gameObject.CompareTag("Player"))
        {
			// Add health to Player and destroy the banana object
            other.GetComponent<playerHealth>().addHealth(healthAmount);
            Rigidbody healthTextbox = Instantiate(healthText, gameObject.transform.position, Quaternion.identity) as Rigidbody;
            Destroy(gameObject);
        }
	}
}
