﻿using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{
   public float fullHealth;
   float currentHealth;

   public GameObject playerDeathFX;

   // Use this for initialization
   void Start ()
   {
      currentHealth = fullHealth;
   }

   // Update is called once per frame
   void Update ()
   {

   }

   public void addDamage (float damage)
   {
      currentHealth -= damage;
      if (currentHealth <= 0)
      {
         makeDead();
      }
   }

   public void makeDead()
   {
      Instantiate(playerDeathFX, transform.position, Quaternion.Euler(newVector3(-90, 0, 0)));
      Destroy(gameObject);
   }
}