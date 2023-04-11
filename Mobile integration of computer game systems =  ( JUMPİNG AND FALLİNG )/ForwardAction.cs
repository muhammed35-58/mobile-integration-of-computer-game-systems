using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{

    [CreateAssetMenu(fileName = "StateEvent", menuName = "Data/AvailableStateData/ForwardAction")]
    public class ForwardAction : DataBase
    {


        public float Speed;
        public AnimationCurve GraphicSpeed;
        public float HitDistance;

        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {

        }


        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            MyController mycontroller = availablestate.RetrieveMyController(animator);

            if (!mycontroller.Left)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
                //return;
            }

            if (!mycontroller.Right)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
                //return;
            }


            if (!mycontroller.ZMove)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
                //return;
            }

            if (!mycontroller.InverseZMove)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
            }

            if (mycontroller.Left && mycontroller.Right)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
                //return;
            }


            if (mycontroller.Left && mycontroller.ZMove)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
                //return;
            }

            if (mycontroller.Right && mycontroller.ZMove)
            {
                animator.SetBool(AnimTransition.IsWalk.ToString(), false);
                //return;
            }

            // --------------


            if (mycontroller.Left)
            {
                mycontroller.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);

                if (!IsCheck(mycontroller, Vector3.left))
                {
                    mycontroller.transform.Translate(Vector3.forward * Speed * GraphicSpeed.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);

                }

            }

            if (mycontroller.Right)
            {
                mycontroller.transform.rotation = Quaternion.Euler(0f, -270f, 0f);
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);

                if (!IsCheck(mycontroller, Vector3.right))
                {
                    mycontroller.transform.Translate(Vector3.forward * Speed * GraphicSpeed.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);

                }

            }

            if (mycontroller.ZMove)
            {
                mycontroller.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);

                if (!IsCheck(mycontroller, Vector3.forward))
                {
                    mycontroller.transform.Translate(Vector3.forward * Speed * GraphicSpeed.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);

                }

            }

            if (mycontroller.InverseZMove)
            {
                mycontroller.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
                animator.SetBool(AnimTransition.IsWalk.ToString(), true);

                if (!IsCheck(mycontroller, -Vector3.forward))
                {
                    mycontroller.transform.Translate(Vector3.forward * Speed  * GraphicSpeed.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);

                }

            }

            if (mycontroller.Jump)
            {
                animator.SetBool(AnimTransition.IsJump.ToString(), true);

                if (!IsCheck(mycontroller, Vector3.up))
                {
                    mycontroller.transform.Translate(Vector3.forward * Speed * GraphicSpeed.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);

                }


            }


        }


        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {

        }


        bool IsCheck(MyController mycontroller, Vector3 direction)
        {

            foreach (GameObject sphere in mycontroller.ListFrountSpheres)
            {

                Debug.DrawRay(sphere.gameObject.transform.position, direction * 0.5f, Color.black);
                RaycastHit hit;


                if (Physics.Raycast(sphere.gameObject.transform.position, direction, out hit, HitDistance))
                {
                    return true;

                }



            }


            return false;

        }




    }






}


