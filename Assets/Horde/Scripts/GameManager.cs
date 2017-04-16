﻿using System.Collections;
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
   private int roundMonkeys;
   private int monkeyCount;
   private float monkeyHealth;
   private float monkeyDamage;
   private float monkeySpawnTime;
   private float itemSpawnTime;

	// Use this for initialization
	void Start ()
	{
		lives = player.GetComponent<playerHealth>().lives;
      startWait = new WaitForSeconds(startDelay);
      endWait = new WaitForSeconds(endDelay);
      
		StartHordeMode ();
	}

	public void StartHordeMode()
	{
		//SpawnPlayer();
		StartCoroutine(GameLoop());

		items [2].GetComponent<ammoPickup> ().ammoAmount = 4;

      roundMonkeys = 5;
		monkeySpawnTime = Time.fixedTime;
		itemSpawnTime = Time.fixedTime + itemSpawnDelay;
      monkeyDamage = 0.5f;
      monkeyHealth = 50;
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
      
      if(roundNumber > 0)
      {
         message.text = "ROUND " + roundNumber;
      }
      
      roundNumber++;
      
      monkeyCount = roundMonkeys;
      
      yield return startWait;
   }
   
   private IEnumerator RoundPlaying ()
   {
      message.text = "";
      
      while (lives > 0 && (monkeyCount > 0 || getMonkeysInPlay() > 0))
      {
         SpawnMonkey();
         SpawnItem();
         
         yield return null;
      }
   }
   
   private IEnumerator RoundEnding ()
   {
      if (roundNumber % 2 == 0)
      {
         roundMonkeys++;
      }
      
      if (roundNumber % 3 == 0)
      {
         monkeyHealth += 25.0f;
         monkeyDamage *= 1.5f;
      }
      
      yield return endWait;
   }
   
   private void ResetPlayer()
   {
      player.GetComponent<Rigidbody>().transform.position = playerSpawn.transform.position;
   }
   
   private void SpawnMonkey ()
   {
		GameObject spawnedMonkey;

      if (getMonkeysInPlay() < 5)
		{
         int spawn = Random.Range(0,4);
		      
			if (Time.fixedTime > monkeySpawnTime && monkeyCount > 0)
	      {
		      if (SafeToSpawn(monkeySpawn[spawn].position, "Enemy"))
				{
					spawnedMonkey = Instantiate(monkey, monkeySpawn[spawn].position, monkeySpawn[spawn].rotation) as GameObject;
					Debug.Log ("monkey spawned at " + monkeySpawn[spawn].position);
					spawnedMonkey.GetComponent<MonkeyControllerTest>().detected = true;
               spawnedMonkey.GetComponent<EnemyHealth>().enemyMaxHealth = monkeyHealth;
               spawnedMonkey.GetComponent<EnemyHealth>().damageModifier = monkeyDamage;

					if (spawn == 1 || spawn == 2)
					{
						spawnedMonkey.GetComponent<MonkeyControllerTest> ().Flip ();
					}
				}

				monkeyCount--;
				monkeySpawnTime = Time.fixedTime + monkeySpawnDelay;
		   }
	   }
   }
   
   private int getMonkeysInPlay ()
   {
      List<GameObject> instances = new List<GameObject>();
      GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
      int count = 0;
      
      foreach (GameObject obj in objects)
		{
			if (obj.tag == "Enemy")
			{
				count++;
			}
		}
      
      return count;
   }
   
	private bool SafeToSpawn(Vector3 position, string objectTag)
   {
      List<GameObject> instances = new List<GameObject>();
		GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		bool nearby = false;
	
		foreach (GameObject obj in objects)
		{
			if (obj.tag == objectTag)
			{
				instances.Add(obj);
			}
		}

		foreach (GameObject obj in instances)
		{
			if (obj.transform.position.x > position.x - 3.0f && obj.transform.position.x < position.x + 3.0f)
			{
				nearby = true;
			}
		}

		return !nearby;
   }
   
   private void SpawnItem ()
   {
      int spawn = Random.Range(0,3);
      int item = Random.Range(0,3);
      
		if (Time.fixedTime> itemSpawnTime)
      {
			if (SafeToSpawn(itemSpawn[spawn].position, "Pickups"))
			{
				Instantiate(items[item], itemSpawn[spawn].position, itemSpawn[spawn].rotation);
				Debug.Log (items[item] + " spawned at " + itemSpawn[spawn].position);
			}
			
			itemSpawnTime = Time.fixedTime + itemSpawnDelay;
      }
   }
}
