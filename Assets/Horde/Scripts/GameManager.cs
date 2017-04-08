using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject player;
   public GameObject monkey;
   public GameObject[] items;
	public Transform playerSpawn;
	public Transform[] monkeySpawn;
	public Transform[] itemSpawn;
   public float startDelay = 3.0f;
   public float endDelay = 3.0f;
   public Text message;

	private int roundNumber = 0;
   private WaitForSeconds startWait;
   private WaitForSeconds endWait;
   private GameOver gameOverScript;
   private int lives;
   private int roundMonkeys = 5;
   private int monkeyCount;
   private int monkeyHealth;
   private int monkeyDamage;

	// Use this for initialization
	void Start ()
	{
		lives = player.GetComponent<playerHealth>().lives;
      startWait = new WaitForSeconds(startDelay);
      endWait = new WaitForSeconds(endDelay);
      
      SpawnPlayer();
      
      StartCoroutine(GameLoop());
	}
	
   private void SpawnPlayer ()
   {
      Instantiate(player, playerSpawn.position, playerSpawn.rotation);
   }
   
   private IEnumerator GameLoop ()
   {
      yield return StartCoroutine(RoundStarting());
      yield return StartCoroutine(RoundPlaying());
      yield return StartCoroutine(RoundEnding());
      
      if (lives > 0)
      {
         StartCoroutine(GameLoop());
      }
      else
      {
         gameOverScript.endGame();
      }
   }
   
   private IEnumerator RoundStarting ()
   {
      ResetPlayer();
      
      roundNumber++;
      message.text = "ROUND " + roundNumber;
      
      monkeyCount = roundMonkeys;
      
      // Set monkey health and damage
      
      yield return startWait;
   }
   
   private IEnumerator RoundPlaying ()
   {
      message.text = "";
      
      while (lives > 0 && monkeyCount > 0)
      {
         SpawnMonkey();
         SpawnItem();
         
         yield return null;
      }
   }
   
   private IEnumerator RoundEnding ()
   {
      if (roundNumber % 3 == 0)
      {
         roundMonkeys++;
      }
      
      if (roundNumber % 2 == 0)
      {
         monkeyHealth += 5;
         monkeyDamage += 5;
      }
      
      yield return endWait;
   }
   
   private void ResetPlayer()
   {
      player.GetComponent<Rigidbody>().transform.position = playerSpawn.transform.position;
   }
   
   private void SpawnMonkey ()
   {
      
   }
   
   private void SpawnItem ()
   {
      
   }
}
