using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalController : MonoBehaviour
{
   
   public int currentSceneIndex;
   public int gameMode; // Adventure == 1, Horde == 2
   
   // Player stats
	public float playerHealth;
   public int playerLife;
   public int playerAmmo;
   public int playerScore;
   public int easterEggCounter;
   public int monkeysKilled;
   public int rounds;

   [HideInInspector]public int clipIndex;
   /*[HideInInspector]*/public float startTime;
   /*[HideInInspector]*/public float endTime;
	/*[HideInInspector]*/public bool gameOver;

	[HideInInspector]public Dictionary<int, Vector3> spawnpoints = new Dictionary<int, Vector3> ();
	public GameObject scene1Spawnpoint;
	public GameObject scene2Spawnpoint;
	public GameObject scene3Spawnpoint;
	public GameObject scene4Spawnpoint;

	public Transform hordeSpawnpoint;
	
	public static globalController Instance;
   
	void Start ()
	{
		playerHealth     = 100.0f;
      playerLife       = 4;
      playerAmmo       = 20;
      easterEggCounter = 0;
      monkeysKilled    = 0;
      clipIndex        = 1;
      PlayerPrefs.SetInt ("CharacterSelected", 0); // Set default character skin

		spawnpoints [3] = scene1Spawnpoint.transform.position;
		spawnpoints [5] = scene2Spawnpoint.transform.position;
		spawnpoints [6] = scene3Spawnpoint.transform.position;
		spawnpoints [7] = scene4Spawnpoint.transform.position;

		gameOver = false;
	}

    void Awake ()   
	{
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
}
