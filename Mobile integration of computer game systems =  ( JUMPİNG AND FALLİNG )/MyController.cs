using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Linkedin_m
{

    public enum AnimTransition
    {
        IsWalk,
        IsJump,
        IsObligation,
        IsGround,
        IsFalling,
    }

    public class MyController : MonoBehaviour
    {
        public bool Left;
        public bool Right;
        public bool Jump;
        public bool ZMove;
        public bool InverseZMove;

        public bool IsObligation;

        public GameObject BoundsForSphere;

        public  List<GameObject> ListBottomSpheres = new List<GameObject>();
        public List<GameObject> ListFrountSpheres = new List<GameObject>();


        public float GravityValue;
        public float PullValue;

        private void Awake()
        {
            BoxCollider box = GetComponent<BoxCollider>();


           float bottom = box.bounds.center.y - box.bounds.extents.y ;
            float front = box.bounds.center.z + box.bounds.extents.z;
            float top = box.bounds.center.y + box.bounds.extents.y;
            float back = box.bounds.center.z - box.bounds.extents.z;

            GameObject o_BottomFront= CreateBoundsForSphere(new Vector3(0f, bottom, front));
            o_BottomFront.transform.parent = this.transform;


            GameObject o_TopFront = CreateBoundsForSphere(new Vector3(0f, top, front));
            o_TopFront.transform.parent = this.transform;

            GameObject o_BottomBack = CreateBoundsForSphere(new Vector3(0f, bottom, back));
            o_BottomBack.transform.parent = this.transform;

            ListBottomSpheres.Add(o_BottomBack);
            ListBottomSpheres.Add(o_BottomFront);

            ListFrountSpheres.Add(o_BottomFront);
            ListFrountSpheres.Add(o_TopFront);

            float horiDistance = (o_BottomBack.transform.position - o_BottomFront.transform.position).magnitude / 5f;

            float vertiDistance = (o_BottomFront.transform.position - o_TopFront.transform.position).magnitude / 9f;

            MiddleSpheres(o_BottomBack, transform.forward, horiDistance, 4,ListBottomSpheres);
            MiddleSpheres(o_BottomFront, transform.up, vertiDistance, 8, ListFrountSpheres);

        }


        private Rigidbody rigid;

        public Rigidbody RIGIDBODY
        {

            get
            {
                if (rigid == null)
                {
                    rigid = this.gameObject.transform.GetComponent<Rigidbody>();

                }

                return rigid;
            }


        }

        public GameObject CreateBoundsForSphere(Vector3 pos)
        {
            GameObject a = Instantiate(BoundsForSphere, pos, Quaternion.identity);

            return a;
        }

        public void MiddleSpheres(GameObject obje,Vector3 direction,float Distance,int Bound,List<GameObject> AvailableSphereList )
        {
            for (int i = 0; i < Bound; i++)
            {
               GameObject MiddleObjects = CreateBoundsForSphere(obje.transform.position + direction * Distance * (i + 1));
                MiddleObjects.transform.parent = this.gameObject.transform;
                AvailableSphereList.Add(MiddleObjects);
            }
         

        }


        private void FixedUpdate()
        {
            if(RIGIDBODY.velocity.y>0 && !Jump)
            {
                RIGIDBODY.velocity += (-Vector3.up * PullValue);
            }

            if (RIGIDBODY.velocity.y < 0)
            {
                RIGIDBODY.velocity += (-Vector3.up * GravityValue);
            }
        }



    }


}


