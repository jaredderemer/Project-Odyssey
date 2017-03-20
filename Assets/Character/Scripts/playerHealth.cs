using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
   public float fullHealth; // Player's max health
   public float currentHealth;     // The current level of health for the character
   public Image healthBarFill;
   private Color MaxHealthColor = Color.green;
   private Color MinHealthColor = Color.red;

   public Slider healthSlider;
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
        
      // Update health slider
      //updateHealthSlider();

      if (currentHealth <= 0)
      {
         makeDead();
         print("JOHN SUN DIED!!!");
      }
   }

   // Add health to character
   public void addHealth (float healthAmount)
   {
      if ((fullHealth - currentHealth) > healthAmount)
         currentHealth += healthAmount;
      else
         currentHealth = fullHealth;
        
      // Update health slider
      updateHealthSlider();
     
   }
   
   // Update the health bar color based on health percentage
   public void updateHealthSlider ()
   {
       float currHealthPercent = (currentHealth / fullHealth);
       
       // Update health bar slider value
       /*healthSlider.value = currentHealth;
       
       // Change health bar color
       if(currHealthPercent > .65)
           healthBarFill.color = new Color(.3f, .69f, .31f);  // Green
       else if(currHealthPercent > .4)
           healthBarFill.color = new Color(1.0f, .76f, .03f); // Yellow
       else if(currHealthPercent > .2)
           healthBarFill.color = new Color(1.0f, .34f, .13f); // Orange
       else
           healthBarFill.color = new Color(.96f, .26f, .21f); // Red
        */
   }

   public void makeDead ()
   {
      Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
      Destroy(gameObject);
   }
}