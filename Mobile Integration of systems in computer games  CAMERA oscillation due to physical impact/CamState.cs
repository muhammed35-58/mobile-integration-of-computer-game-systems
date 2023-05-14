using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    public class CamState : StateMachineBehaviour
    {

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            EnumCameraTransition[] arr = System.Enum.GetValues(typeof(EnumCameraTransition)) as EnumCameraTransition[];

            foreach (EnumCameraTransition e in arr)
            {
                CamDirector.ForExample.CAMCONTROL.CAMERANÝMATOR.ResetTrigger(e.ToString());
            }
        }



    }


}


