using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatforminput
{
    public class ButtonHandler : MonoBehaviour
    {

        public string Name;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            CrossPlatforminputManager.SetButtonDown(Name);
        }


        public void SetUpState()
        {
            CrossPlatforminputManager.SetButtonUp(Name);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatforminputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatforminputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatforminputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
