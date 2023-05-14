using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{

    public class ContactControl : MonoBehaviour
    {
        private MyController Character;
        BodySections DamagedbodySection;


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

                if (! griff.IsAttackSave)
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
            foreach (C_Trigger trigger in Character.GetAllTriggers()) 
            {
                foreach (Collider col in trigger.ListCollidingPiece)
                {
                    foreach (string name in griff.colliderNames)
                    {
                        if (name==col.gameObject.name)
                        {
                            DamagedbodySection = trigger.bodySections;
                            return true;
                        }
                    }
                }
            }

            return false;
        }



        void DetrimentGive(AttackGriff griff)
        {

            CamDirector.ForExample.SwitchCamera(0.8f);
            //Debug.Log("KAFAN BANA DEÐDÝ ! ! ! ");
      
            Debug.Log(" Kafanýn temas ettiði Vücut bölümü : " + DamagedbodySection.ToString() + " - dýr. " );

            //Character.my_Animator.runtimeAnimatorController = griff.attacks.GetDeathAnim();
            Character.my_Animator.runtimeAnimatorController = DeathDirector.ForExample.GetRunAnimatorController(DamagedbodySection);
          
            Character.gameObject.GetComponent<BoxCollider>().enabled = false;
            Character.gameObject.GetComponent<Rigidbody>().useGravity = false;



        }

    }


}


