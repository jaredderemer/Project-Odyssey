using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalController : MonoBehaviour
{
	public float  playerHealth;
   public int currentSceneIndex;
	
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
    }
}
