using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{
    public class PoolObject : MonoBehaviour
    {
        public PoolObjType poolObjType;
        private Coroutine AvailableCoroutine;
        public float WaitTime;
        private void OnEnable()
        {
            Debug.Log("ACTÝVATED ! ");

            if (AvailableCoroutine != null)
            {

                StopCoroutine(ActivePassive(WaitTime));
            }

            if (WaitTime > 0f)
            {
                AvailableCoroutine = StartCoroutine(ActivePassive(WaitTime));
            }

            
        }

        public void Close()
        {
            PoolDirector.ForExample.AddAndPassive(this);
        }
        IEnumerator ActivePassive(float WaitTime)
        {
            yield return new WaitForSeconds(WaitTime);
            if(!PoolDirector.ForExample.PoolDicti[poolObjType].Contains(this.gameObject))
            {
                Close();
            }
           

        }

    }

    
}


