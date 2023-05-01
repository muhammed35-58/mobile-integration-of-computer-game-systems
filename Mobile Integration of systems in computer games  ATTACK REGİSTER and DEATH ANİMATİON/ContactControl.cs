using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    public class ContactControl : MonoBehaviour
    {
        private MyController Character;


        private void Start()
        {
            Character = this.gameObject.GetComponent<MyController>();
        }

        private void Update()
        {
            if (AttackDirector.ForExample.AttackGriffList.Count > 0)
            {
                ControlTheAttack();
            }



        }

        void ControlTheAttack()
        {

            foreach (AttackGriff griff in AttackDirector.ForExample.AttackGriffList)
            {


                if (griff == null)
                {
                    continue;
                }

                if (griff.IsAnimFinish)
                {
                    continue;
                }

                if (IsCollisionOccur(griff))
                {
                    DetrimentGive(griff);
                }
               

            }

        }

        bool IsCollisionOccur(AttackGriff griff)
        {
            foreach (Collider c in Character.ListCollidingPiece)
            {
                foreach (string name in griff.colliderNames)
                {
                    if (c.gameObject.name == name)
                    {
                      
                        return true;
                    }
                }
            }

            return false;
        }

        void DetrimentGive(AttackGriff griff)
        {
            Debug.Log("KAFAN BANA DEÐDÝ ! ! ! ");

            Character.my_Animator.runtimeAnimatorController = griff.attacks.GetDeathAnim();
        }

    }


}


