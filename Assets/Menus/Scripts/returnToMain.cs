using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returnToMain : MonoBehaviour
{
   public GameObject UI;

   // Return to main menu and destroy old UI object
   public void ReturnToMain ()
   {
      SceneManager.LoadScene ("mainMenu");
      Destroy (UI);
   }
}
