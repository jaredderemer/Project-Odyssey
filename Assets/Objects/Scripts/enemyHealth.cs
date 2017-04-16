using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour 
{
   public int health;  // Enemy health

   public void addDamage(int damageAmount)
   {
      health -= damageAmount;
      if (health <= 0) 
      {
         Destroy (gameObject);
         globalController.Instance.monkeysKilled += 1;
      }
   }
}
