using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{
   public int fullHealth;    // Player's max health

   public int currentHealth; // The current level of health for the character

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
   public void AddDamage (int damage)
   {
      currentHealth -= damage;

      if (currentHealth <= 0)
      {
         MakeDead();
      }
   }

   public void AddHealth (int healthAmount)
   {
      if ((fullHealth - currentHealth) > healthAmount)
         currentHealth += healthAmount;
      else
         currentHealth = fullHealth;
   }

   public void MakeDead ()
   {
      Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
      Destroy(gameObject);
   }
}