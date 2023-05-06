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


        public List<RuntimeAnimatorController> DeathAnimators = new List<RuntimeAnimatorController>();
        private List<AttackGriff> FinishedAttacks = new List<AttackGriff>();
        public override void AnimStart(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {


            GameObject obj = PoolDirector.ForExample.GetPoolObj(PoolObjType.AttackGriff);
            AttackGriff griff = obj.GetComponent<AttackGriff>();

            obj.SetActive(true);

            griff.ResetAttack(this,availablestate.RetrieveMyController(animator));


            if (!AttackDirector.ForExample.AttackGriffList.Contains(griff))
            {
                AttackDirector.ForExample.AttackGriffList.Add(griff);
            }


        }

        public override void AnimUpdate(AvailableState availablestate, Animator animator, AnimatorStateInfo stateInfo)
        {

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
                   
                    if(!griff.IsAnimFinish && griff.attacks==this )
                    {
                        griff.IsAnimFinish = true;
                        //Destroy(griff.gameObject);
                        griff.gameObject.GetComponent<PoolObject>().Close();
                       
                    }
                  

                }
            }
        }

        public void Clear()
        {
            //for (int i = 0; i < AttackDirector.ForExample.AttackGriffList.Count; i++)
            //{
            //    if(AttackDirector.ForExample.AttackGriffList[i].IsAnimFinish || AttackDirector.ForExample.AttackGriffList[i] == null)
            //    {
            //        AttackDirector.ForExample.AttackGriffList.RemoveAt(i);
            //    }
            //}

            FinishedAttacks.Clear();


            foreach (AttackGriff griff in AttackDirector.ForExample.AttackGriffList)
            {
                if (griff == null || griff.IsAnimFinish)
                {

                    FinishedAttacks.Add(griff);
                }

            }

            foreach (AttackGriff griff in FinishedAttacks)
            {
                if (AttackDirector.ForExample.AttackGriffList.Contains(griff))
                {
                    AttackDirector.ForExample.AttackGriffList.Remove(griff);

                }
            }

        }

        public RuntimeAnimatorController GetDeathAnim()
        {
            return DeathAnimators[0];
        }
    }

}


