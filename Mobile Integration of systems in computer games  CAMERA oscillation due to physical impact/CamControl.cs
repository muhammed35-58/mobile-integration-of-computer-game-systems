using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    public enum EnumCameraTransition
    {
        DefaultCam,
        OscillationCam,
    }
    public class CamControl : MonoBehaviour
    {
        private Animator anim;
        public Animator CAMERANÝMATOR
        {
            get
            {
                if (anim == null)
                {
                    anim = gameObject.GetComponent<Animator>();
                }
                return anim;
            }
        }

        public void CameraTrigger(EnumCameraTransition enumCameraTransition)
        {
            CAMERANÝMATOR.SetTrigger(enumCameraTransition.ToString());
        }

    }


}


