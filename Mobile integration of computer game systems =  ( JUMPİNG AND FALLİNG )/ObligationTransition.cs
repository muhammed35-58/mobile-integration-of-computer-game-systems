using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Linkedin_m
{

    [CreateAssetMenu(fileName = "StateEvent", menuName = "Data/AvailableStateData/ObligationTransition")]
    public class ObligationTransition : DataBase
    {

        [Range(0.01f, 1f)]
        public float ObligationTransitionTiming;

        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }

        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
          
            if (stateInfo.normalizedTime > ObligationTransitionTiming)
            {
                animator.SetBool(AnimTransition.IsObligation.ToString(), true);

                //if (mycontroller.Jump)
                //{
                //    animator.SetBool(AnimTransition.IsJump.ToString(), false);
                //}

            }


        }


        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(AnimTransition.IsObligation.ToString(), false);
        }


    }

}
