using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scrollingText : MonoBehaviour {

	Text scrollText;
	float speed;

	// Use this for initialization
	void Start () {
		scrollText = GameObject.Find("scrollText").GetComponent<Text>();
		speed = .3f;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = scrollText.transform.position;
		position.y += speed;
		scrollText.transform.position = position;
	}
}
