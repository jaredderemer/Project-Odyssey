using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalController : MonoBehaviour
{
	public float  playerHealth;
    public int currentSceneIndex;

	private Dictionary<string, GameObject> spawnpoints = new Dictionary<string, GameObject> ();
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

		spawnpoints ["scene1"] = scene1Spawnpoint;
		spawnpoints ["scene2"] = scene2Spawnpoint;
		spawnpoints ["scene3"] = scene2Spawnpoint;
		spawnpoints ["scene4"] = scene2Spawnpoint;
    }
}
