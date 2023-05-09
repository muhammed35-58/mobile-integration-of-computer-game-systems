using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    public class DeathDirector : OneExample<DeathDirector>
    {
        List<RuntimeAnimatorController> Applicants = new List<RuntimeAnimatorController>();
        DeathLoader deathLoader;

        void SetUpDeathLoader()
        {
            if (deathLoader == null)
            {
                GameObject obj = Instantiate(Resources.Load("DeathLoader", typeof(GameObject)) as GameObject);
                DeathLoader loader = obj.GetComponent<DeathLoader>();
                deathLoader = loader;
            }
        }

        public RuntimeAnimatorController ReceiveAnimator(BodySections DamagedbodySections)
        {
            SetUpDeathLoader();
            Applicants.Clear();

            foreach (DeathData data in deathLoader.ListDeathData)
            {
                foreach (BodySections Determinebodysection in data.ListBodySections)
                {
                    if (Determinebodysection == DamagedbodySections)
                    {
                        Applicants.Add(data.runTimeAnimator);
                        break;
                    }
                }
            }

            return Applicants[Random.Range(0,Applicants.Count)]; // Diðer Animator Controlcü eklenmediði için zaten mevcut olan
                                                                 // animatorControlcüsünü oynatacaktýr.

           


        }

    }

}


