using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{

    [CreateAssetMenu(fileName = "StateEvent", menuName = "Data/AvailableStateData/Landing")]
    public class Landing : DataBase
    {


        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(AnimTransition.IsJump.ToString(), false); // bence ko�ul yazmam�z laz�m ! ! !
            animator.SetBool(AnimTransition.IsWalk.ToString(), false);

            // E�er tam d��me esnas�nda z�plama tu�una bas�p tekrar z�plama gibi bir hata al�yorsan bence sadece �stteki kodlar
            // yerine  Controlc� e�er Jump butununa basarsa e�er   ko�ulunu ekleyerek �stteki kodlar� yaz.

            //MyController mycontroller = availablestate.RetrieveMyController(animator);

            //if (mycontroller.Jump)
            //{
            //    animator.SetBool(AnimTransition.IsJump.ToString(), false);
            //    animator.SetBool(AnimTransition.IsWalk.ToString(), false);
            //}

        }

        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
           
        }


        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }


    }



}


