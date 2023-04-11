using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    public class HandInput : MonoBehaviour
    {

        private MyController mycontrol;

        private void Awake()
        {
            mycontrol = this.gameObject.GetComponent<MyController>();

        }

        private void Update()
        {
            if (ImaginaryInput.ForExample.Left)
            {
                mycontrol.Left = true;
            }
            else
            {
                mycontrol.Left = false;
            }

            if (ImaginaryInput.ForExample.Right)
            {
                mycontrol.Right = true;
            }

            else
            {
                mycontrol.Right = false;
            }

            if (ImaginaryInput.ForExample.ZMove)
            {
                mycontrol.ZMove = true;

            }

            else
            {
                mycontrol.ZMove = false;
            }

            if (ImaginaryInput.ForExample.InverseZMove)
            {
                mycontrol.InverseZMove = true;
            }

            else
            {
                mycontrol.InverseZMove = false;
            }

            if (ImaginaryInput.ForExample.Jump)
            {
                mycontrol.Jump = true;
            }

            else
            {
                mycontrol.Jump = false;
            }

            if (ImaginaryInput.ForExample.IsObligation)
            {
                mycontrol.IsObligation = true;
            }

            else
            {
                mycontrol.IsObligation = false;
            }


        }

    }



}


