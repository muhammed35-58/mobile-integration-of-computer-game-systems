using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{

    public enum PoolObjType
    {
        AttackGriff,
    }

    public class PoolObjLoader : MonoBehaviour
    {

        public static PoolObject LoadPoolObj(PoolObjType poolObjType )
        {
            GameObject obj = null;

            switch (poolObjType)
            {
                case PoolObjType.AttackGriff:
                    {                     
                        obj = Instantiate(Resources.Load("AttackGriff", typeof(GameObject)) as GameObject);
                        break;
                    }
                  
               
            }

            return obj.GetComponent<PoolObject>();
        }





    }



}

