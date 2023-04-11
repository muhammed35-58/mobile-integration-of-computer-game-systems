using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{

    public abstract class DataBase : ScriptableObject
    {

        public abstract void AnimStart(AvailableState availablestate,Animator animator,AnimatorStateInfo stateInfo);

        public abstract void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo);

        public abstract void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo);



    }


}


