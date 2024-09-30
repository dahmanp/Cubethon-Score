using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
        public float forwardForce = 2000f;
        public float sidewaysForce = 500f;
        //private Score score;
        private bool Opposite;

        void FixedUpdate()
        {
            if (!Opposite)
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime);

                if (Input.GetKey("d"))
                {
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }

                if (Input.GetKey("a"))
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }

                if (rb.position.y < -1f)
                {
                    FindObjectOfType<GameManager>().EndGame();
                }
            }
        }

        /*public override void Notify(Subject subject)
        {
            if (!score)
            {
                score = subject.GetComponent<Score>();
            }
            if (score)
            {
                Opposite = score.OppositeScore;
            }
        }*/
    }

