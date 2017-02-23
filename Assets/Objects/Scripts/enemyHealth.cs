using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour 
{
    public int health;  // Enemy health

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void addDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Destroy(gameObject);
    }
}
