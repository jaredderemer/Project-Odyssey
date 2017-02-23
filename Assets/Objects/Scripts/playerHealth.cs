using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{
   public float fullHealth; // Player's max health
   float currentHealth;     // The current level of health for the character

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

   // Adds health to the player upon collecting Health Item
   public void addHealth(float healthAmount)
   {
      if ((fullHealth - currentHealth) > healthAmount)
         currentHealth += healthAmount;
      else
         currentHealth = fullHealth;
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

   // calls death animation...
   public void makeDead()
   {
      Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
      Destroy(gameObject);
   }
}