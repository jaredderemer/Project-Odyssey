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
   public Slider enemyHealthIndicator;

	// Use this for initialization
	void Start ()
   {
      currentHealth = enemyMaxHealth;
      enemyHealthIndicator.maxValue = enemyMaxHealth;
      enemyHealthIndicator.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update ()
   {
		
	}

   public void AddDamage(float damage)
   {
      enemyHealthIndicator.gameObject.SetActive(true);
      damage = damage * damageModifier;
      if (damage <= 0f)
      {
         return;
      }
      Debug.Log("AddDamage");
      
      currentHealth -= damage;
      enemyHealthIndicator.value = damage / enemyMaxHealth;

      if (currentHealth <= 0)
      {
         MakeDead();
      }
   }

   void MakeDead()
   {
      Destroy(gameObject.transform.root.gameObject);

      // Increment monkeys killed global variable
      globalController.Instance.monkeysKilled += 1;

      //if (drops)
      //{
      //   Instantiate(drop, transform.position, transform.rotation);
      //}
   }
}
