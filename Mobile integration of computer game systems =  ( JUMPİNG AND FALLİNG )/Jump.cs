using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    [CreateAssetMenu(fileName = "StateEvent", menuName = "Data/AvailableStateData/Jump")]
    public class Jump : DataBase
    {

        public float JumpForce;
        public AnimationCurve PullCurve;
        public AnimationCurve GravityCurve;

      
        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            availablestate.RetrieveMyController(animator).RIGIDBODY.AddForce(Vector3.up * JumpForce);
            animator.SetBool(AnimTransition.IsGround.ToString(), false);
            animator.SetBool(AnimTransition.IsWalk.ToString(), false);
        }


        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            MyController mycontroller = availablestate.RetrieveMyController(animator);

            mycontroller.GravityValue = PullCurve.Evaluate(stateInfo.normalizedTime);
            mycontroller.PullValue = GravityCurve.Evaluate(stateInfo.normalizedTime);

        }


        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            

        }


    }



}

