using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTest : MonoBehaviour
{
	public GameObject target;

	private Transform camTransform;

	// Use this for initialization
	void Start ()
	{
		camTransform = target.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target != null)
		{
			transform.position = new Vector3(camTransform.position.x,
                                          camTransform.position.y,
                                             transform.position.z);
		}
	}
}
