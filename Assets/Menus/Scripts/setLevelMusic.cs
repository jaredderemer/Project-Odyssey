using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setLevelMusic : MonoBehaviour
{
   public int musicSelection;
   
	// Use this for initialization
	void Start ()
   {
      GameObject.Find("UI").GetComponent<PlayMusic>().PlaySelectedMusic(musicSelection);
	}
}
