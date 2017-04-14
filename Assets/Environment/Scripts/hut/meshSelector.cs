/*******************************************************************************
* Author          MM/DD/YY  HH24:MM    Description                             *
* Juju Moong      04/14/17  18:15      Change character mesh and material      *
*                                                                              *
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshSelector : MonoBehaviour {
   [HideInInspector]
   public Material material;
   [HideInInspector]
   public Mesh mesh;

   public void selectMesh (int index)
   {
      string mat;
      string meshType;

      // Assign chosen material and mesh
      switch (index) 
      {
         case 1:
            mat = "miner";
            meshType = "minerMesh";
            break;
         case 2:
            mat = "lambert1";
            meshType = "touristMesh";
            break;
         default:
            mat = "fisherman";
            meshType = "defaultMesh";
            break;
      }
         
      material = Resources.Load(mat, typeof(Material)) as Material;
      mesh     = ((GameObject)Resources.Load(meshType)).GetComponent<SkinnedMeshRenderer>().sharedMesh;

      // Load material and mesh
      loadMesh ();
   }

   public void loadMesh ()
   {
      SkinnedMeshRenderer skin = gameObject.GetComponent<SkinnedMeshRenderer> ();
      skin.sharedMesh = mesh;
      skin.material   = material;
   }
}
