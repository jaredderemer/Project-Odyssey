using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeySkinController : MonoBehaviour
{
	[HideInInspector]public Material material;

	void Start ()
	{
		string mat;
		SkinnedMeshRenderer skin = gameObject.GetComponent<SkinnedMeshRenderer> ();

		if (globalController.Instance.currentSceneIndex == 6) // resort scene
		{
			mat = "tourist";
		}
		else // any other scene
		{
			mat = "monkey";
		}

		material = Resources.Load(mat, typeof(Material)) as Material;
		skin.material = material;
	}
}
