using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{

    public class PoolDirector : OneExample<PoolDirector>
    {
        public Dictionary<PoolObjType, List<GameObject>> PoolDicti = new Dictionary<PoolObjType, List<GameObject>>();

        public void SetUpDicti()
        {
            PoolObjType[] pot = System.Enum.GetValues(typeof(PoolObjType)) as PoolObjType[];

            foreach (PoolObjType p in pot)
            {
                if (!PoolDicti.ContainsKey(p))
                {
                    PoolDicti.Add(p, new List<GameObject>());
                }
            }

        }

        public GameObject GetPoolObj(PoolObjType poolObjType)
        {
            if (PoolDicti.Count == 0)
            {
                SetUpDicti();
            }

            GameObject obj=null;
            List<GameObject> list = PoolDicti[poolObjType];

            if (list.Count <= 0)
            {
                obj = PoolObjLoader.LoadPoolObj(poolObjType).gameObject;
            }
            else
            {
                obj = list[0];
                list.RemoveAt(0);
            }

            return obj;
        }

        public void AddAndPassive(PoolObject poolObject)
        {
            List<GameObject> list = PoolDicti[poolObject.poolObjType];
            list.Add(poolObject.gameObject);
            poolObject.gameObject.SetActive(false);
        }

    }


}

