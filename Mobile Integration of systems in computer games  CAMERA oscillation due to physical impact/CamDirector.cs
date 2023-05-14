using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    public class CamDirector : OneExample<CamDirector>
    {
        private CamControl camControl;
        private Coroutine coroutine;
        public CamControl CAMCONTROL
        {
            get
            {
                if (camControl == null)
                {
                    camControl = GameObject.FindObjectOfType<CamControl>();
                }
                return camControl;
            }
        }

        IEnumerator CoroutineCamera(float second)
        {
            CAMCONTROL.CAMERANÝMATOR.SetTrigger(EnumCameraTransition.OscillationCam.ToString());
            yield return new WaitForSeconds(second);
            CAMCONTROL.CAMERANÝMATOR.SetTrigger(EnumCameraTransition.DefaultCam.ToString());

        }

        public void SwitchCamera(float second)
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
            }

            coroutine = StartCoroutine(CoroutineCamera(second));
        }

    }

}


