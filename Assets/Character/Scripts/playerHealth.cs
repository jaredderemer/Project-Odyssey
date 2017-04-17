using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
   public float fullHealth; // Player's max health
   public float currentHealth;     // The current level of health for the character
   public Image healthBarFill;

   public Slider healthSlider;
   public GameObject playerDeathFX;
	//public GameObject player;            DO WE NEED THIS?
   
   public static playerHealth Instance; // For access to playerHealth functions
   
   private GameOver gameOverScript;
   
   public int lives;

	void Awake()
	{
       //lives = 4; 
        lives = 0;  // FOR TESTING!!!! PLZ REMOVE
       savePlayerLife ();
	}

   // Use this for initialization
   void Start ()
   {
      gameOverScript = GameObject.Find("UI").GetComponent<GameOver> ();
      
      // Get global health
      currentHealth = globalController.Instance.playerHealth;
      updateHealthSlider();
   }

   
   // Character receives damage, loses health
   public void addDamage (float damage)
   {
      currentHealth -= damage;
        
      // Update health slider
      updateHealthSlider();
      savePlayerHealth ();

      if (currentHealth <= 0)
      {
         loseLife();
         print("JOHN SUN DIED!!!");
      }
   }

   // Add health to character
   public void addHealth(float healthAmount)
   {
      if ((fullHealth - currentHealth) > healthAmount)
         currentHealth += healthAmount;
      else
         currentHealth = fullHealth;
        
      // Update health slider
      updateHealthSlider();
      savePlayerHealth ();
     
   }
   
   // Update the health bar color based on health percentage
   public void updateHealthSlider()
   {
      
      Debug.Log("Current Health: " + currentHealth);
      
       float currHealthPercent = (currentHealth / fullHealth);
       
       // Update health bar slider value
       healthSlider.value = currentHealth;
       
       // Change health bar color
       if(currHealthPercent > .65)
           healthBarFill.color = new Color(.3f, .69f, .31f);  // Green
       else if(currHealthPercent > .4)
           healthBarFill.color = new Color(1.0f, .76f, .03f); // Yellow
       else if(currHealthPercent > .2)
           healthBarFill.color = new Color(1.0f, .34f, .13f); // Orange
       else
           healthBarFill.color = new Color(.96f, .26f, .21f); // Red
   }

   public void savePlayerHealth()
   {
      globalController.Instance.playerHealth = currentHealth;
   }

   public void savePlayerLife()
   {
      globalController.Instance.playerLife = lives + 1;
   }
   
   public void loseLife()
   {
      lives--;
      savePlayerLife();
      // Remove life from HUD
      if(lives > 0)
      {
         GameObject.Find("life"+ lives.ToString()).SetActive(false);
      }

		if (lives < 0)
		{
			lives = 4; // Same as five lives since the "fifth" life is currently being used and will not be displayed

			// End Gameplay
			globalController.Instance.gameOver = true;
			gameOverScript.endGame();
		}
		else
		{
			GetComponent<PlayerControllerTest>().RespawnPlayer();
			currentHealth = fullHealth;
			globalController.Instance.playerHealth = fullHealth;
			updateHealthSlider();
         savePlayerLife ();
		}
   }
}
