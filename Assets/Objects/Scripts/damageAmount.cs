using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageAmount : MonoBehaviour {

    public float damage;
    GameObject thePlayer;

	// Use this for initialization
	void Start () 
   {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // Applies damage to the enemy once contact is made
    void OnTriggerEnter(Collider other)
    {
        //&& thePlayer.GetComponent<Animator>().charMelee is set
        // Need to check if the melee trigger is set
       
       if (other.gameObject.CompareTag("Enemy"))
       {
           other.GetComponent<EnemyHealth>().AddDamage(damage);
           //this.GetComponent<Collider>().isTrigger = false;
       }

    }

}
