using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{


    [CreateAssetMenu(fileName ="StateEvent",menuName ="Data/AvailableStateData/IdleStateData")]
    public class Idle : DataBase
    {
       

        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(AnimTransition.IsJump.ToString(), false);
            //animator.SetBool()
        }

        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            MyController mycontroller = availablestate.RetrieveMyController(animator);


            if (mycontroller.Left)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);
            }

            if (  mycontroller.Right)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);
            }

            if (mycontroller.ZMove)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);
            }

            if (mycontroller.InverseZMove)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);
            }

            if (mycontroller.Jump)
            {
                animator.SetBool(AnimTransition.IsJump.ToString(), true);
                //animator.SetBool(AnimTransition.IsFalling.ToString(), false);
            }

            else
            {
                animator.SetBool(AnimTransition.IsJump.ToString(), false);
            }

        }


        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }

    }



}


