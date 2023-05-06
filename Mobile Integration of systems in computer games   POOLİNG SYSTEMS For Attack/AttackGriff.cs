using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    public class AttackGriff : MonoBehaviour
    {
        public  bool IsAttackSave;
        public bool IsAnimFinish;
        public int AvailableAttackNumber;
         public   List<string> colliderNames = new List<string>();
        public Attack attacks;

        public void ResetAttack(Attack attack,MyController Character)
        {
            IsAttackSave = false;
            IsAnimFinish = false;
            AvailableAttackNumber = 0;
        }

        public void SaveAttack(Attack attack)
        {
            IsAttackSave = true;
            AvailableAttackNumber = attack.AvailableAttackNumber;
            AvailableAttackNumber++;

            colliderNames = attack.collidernames;
            attacks = attack;
        }

        private void OnDisable()
        {
            IsAnimFinish = true;
        }

    }


}


