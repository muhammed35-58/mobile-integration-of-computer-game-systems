using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    public class AvailableState : StateMachineBehaviour
    {

        public List<DataBase> AvailableDatabase = new List<DataBase>();

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (DataBase data in AvailableDatabase)
            {
                data.AnimStart(this, animator, stateInfo);
            }
        }


        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }


        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (DataBase data in AvailableDatabase)
            {
                data.AnimExit(this, animator, stateInfo);
            }
        }


        public void UpdateAll(AvailableState availablestate,Animator animator,AnimatorStateInfo stateInfo)
        {
            foreach (DataBase data in AvailableDatabase)
            {
                data.AnimUpdate(availablestate, animator, stateInfo);
            }
        }

        private MyController mycontroller;

        public MyController RetrieveMyController(Animator animator)
        {
            if (mycontroller == null)
            {
               mycontroller =  animator.gameObject.GetComponentInParent<MyController>();
            }

            return mycontroller;
           
        }

    }



}


