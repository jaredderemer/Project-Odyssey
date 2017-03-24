using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalController : MonoBehaviour
{
	public float  playerHealth;
    public int currentSceneIndex;

	[HideInInspector]public Dictionary<string, GameObject> spawnpoints = new Dictionary<string, GameObject> ();
	public GameObject scene1Spawnpoint;
	public GameObject scene2Spawnpoint;
	public GameObject scene3Spawnpoint;
	public GameObject scene4Spawnpoint;
	
	public static globalController Instance;
   
	void Start ()
	{
	  playerHealth = 100;
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

		spawnpoints ["3"] = scene1Spawnpoint;
		spawnpoints ["4"] = scene2Spawnpoint;
		spawnpoints ["5"] = scene3Spawnpoint;
		spawnpoints ["6"] = scene4Spawnpoint;
    }

	public void restartGame ()
	{

	}
}
