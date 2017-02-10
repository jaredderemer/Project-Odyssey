using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class resetCredits : MonoBehaviour {

	Text scrollText;

	// Reset credits text position
	public void Reset () {
		scrollText = GameObject.Find("scrollText").GetComponent<Text>();
		Vector3 position = scrollText.transform.position;
		position.y = 0;
		scrollText.transform.position = position;
	}
}
