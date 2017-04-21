using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageAmount : MonoBehaviour
{
    public float damage;
    GameObject thePlayer;

	private float attackTimer;

	// Use this for initialization
	void Start () 
   {
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		attackTimer = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // Applies damage to the enemy once contact is made
    void OnTriggerEnter(Collider other)
    {               
		if (other.gameObject.CompareTag("Enemy") && attackTimer <= Time.fixedTime) // to avoid multiple attacks in one swing
       {
           other.GetComponent<EnemyHealth>().AddDamage(damage);
           //this.GetComponent<Collider>().isTrigger = false;
       }

    }

}
