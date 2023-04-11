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
            animator.SetBool(AnimTransition.IsJump.ToString(), false); // bence koþul yazmamýz lazým ! ! !
            animator.SetBool(AnimTransition.IsWalk.ToString(), false);

            // Eðer tam düþme esnasýnda zýplama tuþuna basýp tekrar zýplama gibi bir hata alýyorsan bence sadece üstteki kodlar
            // yerine  Controlcü eðer Jump butununa basarsa eðer   koþulunu ekleyerek üstteki kodlarý yaz.

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


