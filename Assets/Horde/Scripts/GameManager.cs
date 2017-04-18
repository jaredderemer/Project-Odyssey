﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject playerSkin;
	public GameObject monkey;
	public Transform[] monkeySpawn;
   public GameObject[] items;
	public Transform[] itemSpawn;
	public GameObject[] lifeSkins;
   public float startDelay = 3.0f;
   public float endDelay = 3.0f;
   public Text message;
   public int monkeySpawnDelay;
   public int itemSpawnDelay;

	private GameObject player;
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
		player = GameObject.FindGameObjectWithTag ("Player");

		lives = player.GetComponent<playerHealth>().lives;
      startWait = new WaitForSeconds(startDelay);
      endWait = new WaitForSeconds(endDelay);

		globalController.Instance.startTime = Time.time;
      
		StartHordeMode ();
	}

	public void StartHordeMode()
	{
		items [2].GetComponent<ammoPickup> ().ammoAmount = 3;

      	roundMonkeys = 5;
		monkeySpawnTime = Time.fixedTime;
		itemSpawnTime = Time.fixedTime + itemSpawnDelay;
      	monkeyDamage = 0.5f;
      	monkeyHealth = 50;

		SpawnPlayer();
		StartCoroutine(GameLoop());
	}
	
   private void SpawnPlayer ()
   {
		SkinnedMeshRenderer skin = playerSkin.GetComponent<SkinnedMeshRenderer> ();
		string mesh;
		string material;

		if (Random.Range (0, 2) == 0)
		{
			mesh = "defaultMesh";
			material = "fisherman";
		}
		else if (Random.Range (0, 2) == 0)
		{
			mesh = "minerMesh";
			material = "miner";
		}
		else
		{
			mesh = "touristMesh";
         material = "touristPlayer";
		}

		skin.material = Resources.Load(material, typeof(Material)) as Material;
		skin.sharedMesh = ((GameObject)Resources.Load(mesh)).GetComponent<SkinnedMeshRenderer>().sharedMesh;

		for (int i = 0; i < lifeSkins.Length; i++)
		{
			SetLifeSkin (i, mesh, material);
		}
   }

	private void SetLifeSkin (int i, string mesh, string material)
	{
		
		SkinnedMeshRenderer skin = lifeSkins[i].GetComponent<SkinnedMeshRenderer> ();

		skin.material = Resources.Load (material, typeof(Material)) as Material;
		skin.sharedMesh = ((GameObject)Resources.Load(mesh)).GetComponent<SkinnedMeshRenderer>().sharedMesh;
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

      if(roundNumber > 0)
      {
         message.text = "ROUND " + roundNumber;
			Debug.Log ("ROUND " + roundNumber);
      }
      
      monkeyCount = roundMonkeys;
      
      yield return startWait;
   }
   
   private IEnumerator RoundPlaying ()
   {
      message.text = "";
      
      while (lives > 0 && (monkeyCount > 0 || getMonkeysInPlay() > 0))
      {
			Debug.Log (lives + " " + monkeyCount + " " + getMonkeysInPlay ());
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
         monkeyHealth *= 1.25f;
         monkeyDamage *= 1.25f;
      }
      
      yield return endWait;
   }
   
   private void ResetPlayer()
   {
		player.GetComponent<Rigidbody> ().transform.position = globalController.Instance.hordeSpawnpoint.position;
   }
   
   private void SpawnMonkey ()
   {
		GameObject spawnedMonkey;

      	if (getMonkeysInPlay() < 5)
		{
			int spawn = Random.Range(0, 4);
		    
			if (Time.fixedTime > monkeySpawnTime && monkeyCount > 0)
	    	{
		    	if (SafeToSpawn(monkeySpawn[spawn].position, "Enemy"))
				{
					spawnedMonkey = Instantiate(monkey, monkeySpawn[spawn].position, monkeySpawn[spawn].rotation) as GameObject;
					Debug.Log ("monkey spawned at " + monkeySpawn[spawn].position);

					spawnedMonkey.GetComponent<MonkeyControllerTest>().detected = true;

					if (true)//Random.Range (0, 4) == 0)
					{
						spawnedMonkey.GetComponent<EnemyHealth> ().enemyMaxHealth = monkeyHealth * 1.25f;
						spawnedMonkey.GetComponent<EnemyHealth> ().damageModifier = monkeyDamage * 1.25f;
						spawnedMonkey.GetComponent<EnemyHealth> ().currentHealth = monkeyHealth * 1.25f;
						spawnedMonkey.GetComponent<EnemyHealth> ().scoreAmount = 125;
						spawnedMonkey.GetComponentInChildren<SkinnedMeshRenderer>().material = Resources.Load("tourist", typeof(Material)) as Material;
					}
					else
					{
						spawnedMonkey.GetComponent<EnemyHealth> ().enemyMaxHealth = monkeyHealth;
						spawnedMonkey.GetComponent<EnemyHealth> ().damageModifier = monkeyDamage;
					}

					if (spawn == 1 || spawn == 2) // to face the right direction on spawn
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
			if (obj.tag == objectTag || obj.tag == "Player")
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
