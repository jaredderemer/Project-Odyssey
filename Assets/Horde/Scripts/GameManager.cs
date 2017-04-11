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
   public int monkeySpawnDelay;
   public int itemSpawnDelay;

	private int roundNumber = 0;
   private WaitForSeconds startWait;
   private WaitForSeconds endWait;
   private GameOver gameOverScript;
   private int lives;
   private int roundMonkeys = 5;
   private int monkeyCount;
   private int monkeyHealth;
   private int monkeyDamage;
   private float monkeySpawnTime;
   private float itemSpawnTime;

	// Use this for initialization
	void Start ()
	{
		lives = player.GetComponent<playerHealth>().lives;
      startWait = new WaitForSeconds(startDelay);
      endWait = new WaitForSeconds(endDelay);
	}

	public void StartHordeMode()
	{
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
      int spawn = Random.Range(0,4);
      
      if (Time.deltaTime >= monkeySpawnTime && monkeyCount > 0)
      {
         Instantiate(monkey, monkeySpawn[spawn].position, monkeySpawn[spawn].rotation);
      }
      
      monkeyCount--;
      monkeySpawnTime = monkeySpawnDelay + Time.deltaTime;
   }
   
   private void SpawnItem ()
   {
      int spawn = Random.Range(0,3);
      int item = Random.Range(0,3);
      
      if (Time.deltaTime >= itemSpawnTime)
      {
			Instantiate(items[item], itemSpawn[spawn].position, itemSpawn[spawn].rotation);
      }
      
      itemSpawnTime = itemSpawnDelay + Time.deltaTime;
   }
}
