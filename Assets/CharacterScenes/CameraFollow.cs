using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // What the camera is going to follow
    public float smoothing = 7.5f; // 


	public float edgeLeft;
	public float edgeRight;
	float halfWidth;
	float maxPosition;
	float minPosition;

    Vector3 offset; // Distance from target camera maintains

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.position;
		halfWidth   = Camera.main.orthographicSize * Screen.width / Screen.height;
		maxPosition = edgeRight - halfWidth;
		minPosition = edgeLeft - halfWidth;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

		// Juju's code for camera
		if (target.position.x >= maxPosition) 
		{
			targetCamPos = new Vector3 (maxPosition, transform.position.y, transform.position.z);
		} 
		else if (target.position.x <= minPosition) 
		{
			targetCamPos = new Vector3 (minPosition, transform.position.y, transform.position.z);
		}
		else 
		{
			targetCamPos = target.position + offset;
		}


		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
