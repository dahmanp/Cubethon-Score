using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class PlayerMovement : Subject
    {
        public Rigidbody rb;
        public float forwardForce = 2000f;
        public float sidewaysForce = 500f;
        private GameManager manager;
        public bool Opposite;

        void Awake()
        {
            manager = gameObject.AddComponent<GameManager>();
        }

        void OnEnable()
        {
            if (manager)
                Attach(manager);
        }
        void OnDisable()
        {
            if (manager)
                Detach(manager);
        }

        void FixedUpdate()
        {
            if (Opposite)
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime);

                if (Input.GetKey("d"))
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }

                if (Input.GetKey("a"))
                {
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }

                if (rb.position.y < -1f)
                {
                    FindObjectOfType<GameManager>().EndGame();
                }
            }
            else
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

        public void ToggleOpposite()
        {
            Opposite = !Opposite;
            NotifyObservers();
        }
    }
}
