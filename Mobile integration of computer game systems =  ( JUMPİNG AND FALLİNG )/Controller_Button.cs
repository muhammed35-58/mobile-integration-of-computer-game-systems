using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{

    public class Controller_Button : MonoBehaviour
    {
        public void LeftButtonDown()
        {
            ImaginaryInput.ForExample.Left = true;
        }

        public void LeftButtonUp()
        {
            ImaginaryInput.ForExample.Left = false;
        }

        public void RightButtonDown()
        {
            ImaginaryInput.ForExample.Right = true;
        }

        public void RightButtonUp()
        {
            ImaginaryInput.ForExample.Right = false;
        }


        public void ZButtonDown()
        {
            ImaginaryInput.ForExample.ZMove = true;
        }

        public void ZButtonUp()
        {
            ImaginaryInput.ForExample.ZMove = false;
        }

        public void InverseZButtonDown()
        {
            ImaginaryInput.ForExample.InverseZMove = true;
        }


        public void InverseZButtonUp()
        {
            ImaginaryInput.ForExample.InverseZMove = false;
        }



        public void JumpButtonDown()
        {
            ImaginaryInput.ForExample.Jump = true;
        }

        public void JumpButtonUp()
        {
            ImaginaryInput.ForExample.Jump = false;
        }





    }


}



