using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    [CreateAssetMenu(fileName = "StateEvent", menuName = "Data/AvailableStateData/Attack")]
    public class Attack : DataBase
    {

        public float StartAttackTime;
        public float EndAttackTime;
        public int AvailableAttackNumber;
        public List<string> collidernames = new List<string>(); 
        AttackGriff griff;

        public List<RuntimeAnimatorController> DeathAnimators = new List<RuntimeAnimatorController>();

        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {

         
            griff = AttackGriffLoader.g_AttackGriffLoader(AnimTransition.IsAttack);

            griff.ResetAttack(this);


            if (!AttackDirector.ForExample.AttackGriffList.Contains(griff))
            {
                AttackDirector.ForExample.AttackGriffList.Add(griff);
            }


        }

        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {

            // Attack Kayýt ve Silme iþlemleri yapýlacak ! ! ! 

            Save(availablestate, animator, stateInfo);
            Erase(availablestate, animator, stateInfo);

        }

        public override void AnimExit(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            Clear();

        }

        public void Save(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (StartAttackTime <= stateInfo.normalizedTime && EndAttackTime > stateInfo.normalizedTime)
            {
                foreach (AttackGriff griff in AttackDirector.ForExample.AttackGriffList)
                {
                    if (griff == null)
                    {
                        continue;
                    }

                    if (  AttackDirector.ForExample.AttackGriffList.Count > 0 && !griff.IsAttackSave)
                    {
                        griff.SaveAttack(this);
                    }

                }

            }
        }


        public void Erase(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime>=EndAttackTime)
            {
                foreach (AttackGriff griff in AttackDirector.ForExample.AttackGriffList)
                {
                   
                    if(!griff.IsAnimFinish)
                    {
                        griff.IsAnimFinish = true;
                        Destroy(griff.gameObject);
                    }
                  

                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < AttackDirector.ForExample.AttackGriffList.Count; i++)
            {
                if(AttackDirector.ForExample.AttackGriffList[i].IsAnimFinish || AttackDirector.ForExample.AttackGriffList[i] == null)
                {
                    AttackDirector.ForExample.AttackGriffList.RemoveAt(i);
                }
            }

        }

        public RuntimeAnimatorController GetDeathAnim()
        {
            return DeathAnimators[0];
        }
    }

}


