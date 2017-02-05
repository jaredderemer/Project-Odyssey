using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class returnToMain : MonoBehaviour
{
	//private Button mainMenu;
	GameObject UI;

	// Use this for initialization
	void Start () {
		UI = GameObject.Find("UI");
	}
	
	// Update is called once per frame
	public void ReturnToMain () {
		SceneManager.LoadScene ("mainMenu");
		Destroy (UI);
	}
}
