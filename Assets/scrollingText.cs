using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrollingText : MonoBehaviour {

	Text scrollText;
	float speed;
	Vector3 startingPosition;
	private Button creditsBack;

	// Use this for initialization
	void Start () {
		scrollText = GameObject.Find("scrollText").GetComponent<Text>();
		startingPosition = scrollText.transform.position;
		speed = .3f;

		creditsBack = GameObject.Find ("CreditsBack").GetComponent<Button> ();
		creditsBack.onClick.AddListener(() => ResetCredits());

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = scrollText.transform.position;
		position.y += speed;
		scrollText.transform.position = position;
	}

	void ResetCredits ()
	{
		Vector3 position = startingPosition;
		scrollText.transform.position = position;
	}

	void Destroy()
	{
		creditsBack.onClick.RemoveListener(() => ResetCredits());
	}
}
