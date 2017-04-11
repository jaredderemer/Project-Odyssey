using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGameMode : MonoBehaviour {

   public int adventureSceneIndex;
   public int hordeSceneIndex;
   
	// Call this function on Adventure Mode Button click
   public void setModeAdventure()
   {
      globalController.Instance.currentSceneIndex = adventureSceneIndex;
      globalController.Instance.gameMode = 1;
   }
	
	// Call this function on Horde Mode Button click
   public void setModeHorde()
   {
      globalController.Instance.currentSceneIndex = hordeSceneIndex; // Set to (index - 1) of HordeScene 
      globalController.Instance.gameMode = 2;
   }
}
