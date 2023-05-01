using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{

    public class AttackGriffLoader : MonoBehaviour
    {
        public static AttackGriff g_AttackGriffLoader(AnimTransition animTransition)
        {
            GameObject obj = null;

            switch (animTransition)
            {

                case AnimTransition.IsAttack:
                    {
                        obj = Instantiate(Resources.Load("AttackGriff", typeof(GameObject)) as GameObject);
                        break;
                    }


            }

            return obj.GetComponent<AttackGriff>();
        }




    }


}


