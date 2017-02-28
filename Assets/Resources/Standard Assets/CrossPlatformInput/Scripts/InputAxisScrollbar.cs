using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatforminput
{
    public class InputAxisScrollbar : MonoBehaviour
    {
        public string axis;

	    void Update() { }

	    public void HandleInput(float value)
        {
            CrossPlatforminputManager.SetAxis(axis, (value*2f) - 1f);
        }
    }
}
