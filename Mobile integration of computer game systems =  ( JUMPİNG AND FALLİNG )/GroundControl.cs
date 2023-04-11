using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    [CreateAssetMenu(fileName = "StateEvent", menuName = "Data/AvailableStateData/GroundControl")]

    public class GroundControl : DataBase
    {

        [Range(0.01f, 1f)]
        public float availableTime;

        public float HitDistance;

        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {


        }


        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            MyController mycontroller = availablestate.RetrieveMyController(animator);



            if (stateInfo.normalizedTime >= availableTime)
            {
                if (IsGrounded(mycontroller))
                {

                    animator.SetBool(AnimTransition.IsGround.ToString(), true);
                }

                else
                {
                    animator.SetBool(AnimTransition.IsGround.ToString(), false);
                }

            }
        }


        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        bool IsGrounded(MyController mycontroller)
        {

            if (mycontroller.RIGIDBODY.velocity.y > -0.01f && mycontroller.RIGIDBODY.velocity.y <= 0f)
            {
                return true;
            }

            if (mycontroller.RIGIDBODY.velocity.y < 0f)
            {

                foreach (GameObject sphere in mycontroller.ListBottomSpheres)
                {

                    Debug.DrawRay(sphere.gameObject.transform.position, -Vector3.up * 0.5f, Color.black);
                    RaycastHit hit;


                    if (Physics.Raycast(sphere.gameObject.transform.position, -Vector3.up, out hit, HitDistance))
                    {
                        return true;

                    }



                }


            }

            return false;

        }






    }


}

