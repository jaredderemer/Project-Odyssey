using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageAmount : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // Applies damage to the enemy once contact is made
    void OnTriggerEnter(Collider other)
    {
       
       if (other.gameObject.CompareTag("Enemy"))
       {
           other.GetComponent<enemyHealth>().addDamage(damage);
           //this.GetComponent<Collider>().isTrigger = false;
       }

    }

}
