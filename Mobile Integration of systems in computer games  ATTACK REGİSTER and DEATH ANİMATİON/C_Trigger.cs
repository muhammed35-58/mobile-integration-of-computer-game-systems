using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Linkedin_m
{

    public class C_Trigger : MonoBehaviour
    {

        MyController Character;

        private void Start()
        {
            Character = this.gameObject.GetComponentInParent<MyController>();
        }

        private void OnTriggerEnter(Collider other)
        {

          MyController Author =  other.gameObject.transform.root.GetComponent<MyController>();

            if (Author == null)
            {
                return;
            }

            if (other.gameObject == Author.gameObject)
            {
                return;
            }

            if (other.gameObject == Character.gameObject)
            {
                return;
            }

            if (Character.ListRagdollPiece.Contains(other))
            {
                return;
            }

            if(!Character.ListCollidingPiece.Contains(other))
            {
                Character.ListCollidingPiece.Add(other);
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (Character.ListCollidingPiece.Contains(other))
            {
                Character.ListCollidingPiece.Remove(other);
            }

        }

    }


}


