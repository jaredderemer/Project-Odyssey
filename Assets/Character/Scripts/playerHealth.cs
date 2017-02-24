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
      updateHealthSlider();

      if (currentHealth <= 0)
      {
         makeDead();
         print("JOHN SUN DIED!!!");
      }
   }

   public void addHealth (float healthAmount)
   {
      if ((fullHealth - currentHealth) > healthAmount)
         currentHealth += healthAmount;
      else
         currentHealth = fullHealth;
        
      // Update health slider
      updateHealthSlider();
     
   }
   
   public void updateHealthSlider ()
   {
       float newRedColor = 0.0f;
       float newGreenColor = 0.0f;
       healthSlider.value = currentHealth;
       
       // Change health bar color
       if(currentHealth <= (fullHealth / 2.0f))
       {
           newGreenColor = ((currentHealth / fullHealth) * 2);
           Debug.Log("new red: " +(newGreenColor * 255.0f));
           healthBarFill.color = new Color(1, newGreenColor, 0);
       }
       else
       {
           newRedColor = (1.0f - (currentHealth / fullHealth));
           Debug.Log("new green: " + (newRedColor * 255.0f));
           healthBarFill.color = new Color(newRedColor, 1, 0);
       }
       
       
   }

   public void makeDead ()
   {
      Instantiate(playerDeathFX, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
      Destroy(gameObject);
   }
}