using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{
    public class OneExample<T> : MonoBehaviour where T : MonoBehaviour
    {

        private static T example;

        public static T ForExample
        {
            get
            {
                if (example == null)
                {
                    GameObject Emptyobj = new GameObject();

                    example = Emptyobj.AddComponent<T>();
                    Emptyobj.name = "Empty Obje " + typeof(T).ToString();

                }

                return example;
            }


        }



    }

}


