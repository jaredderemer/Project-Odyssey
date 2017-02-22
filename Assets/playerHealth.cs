﻿using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{
   public float fullHealth; // Player's max health
   public float currentHealth;     // The current level of health for the character

   public GameObject playerDeathFX;

   // Use this for initialization
   void Start ()
   {
      // Character starts at full health
      currentHealth = fullHealth;
   }

   // Update is called once per frame
   void Update ()
   {

   }
   
   // Character receives damage, loses health
   public void addDamage (float damage)
   {
      currentHealth -= damage;

      if (currentHealth <= 0)
      {
         makeDead();
      }
   }

   // Character received Hit Points 
   public void addHealth(float healthAmount)
   {
       if (currentHealth <= 20)
           currentHealth += healthAmount;
       else
           currentHealth = fullHealth;
   }

   public void makeDead()
   {
      Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
      Destroy(gameObject);
   }
}