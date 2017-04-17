using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
   public float enemyMaxHealth;
   public float damageModifier;
   //public GameObject damageParticles;
   //public bool drops;
   //public GameObject drop;

   public float currentHealth;
   public Slider enemyHealthSlider;
   
   public int scoreAmount = 75; // Point amount received from destroying monkey
   private GameObject HUD;

	// Use this for initialization
	void Start ()
   {
      currentHealth = enemyMaxHealth;
      
      // Get HUD score component
      HUD = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update ()
   {
		
	}

   public void AddDamage(float damage)
   {
      damage = damage * damageModifier;
      
      // Check for valid damage amount
      if(damage > 0.0f)
      {
         currentHealth -= damage;
        
         // Check for dead monkey
         if (currentHealth <= 0)
         {
            
            MakeDead();
            
            // Add points to player score
            // -> here
         }
         else
         {
            // Update health slider
            //updateHealthSlider();
            enemyHealthSlider.value = currentHealth;
         }
      }
   }

   void MakeDead()
   {
      // For cave scene, boss drops key
      if(gameObject.name == "Boss")
      {
         gameObject.GetComponent<monkeyBoss>().dropItem();
      }
      
      // Update globals
      globalController.Instance.monkeysKilled += 1;
      HUD.GetComponent<HUDTest>().updateScore(scoreAmount);
      
      // Destroy gameObject
      Destroy(gameObject.transform.root.gameObject);
      

      //if (drops)
      //{
      //   Instantiate(drop, transform.position, transform.rotation);
      //}
   }
}
