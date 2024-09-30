using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Chapter.Observer
{
    public class Score : Subject
    {
        public Transform player;
        public Text scoreText;
        private CamShook camShook;
        public Camera cam;
        private PNGPop ui;
        public bool drunk = false;
        public bool DrunkScore;
        public bool pngScore;
        public bool blockedScore;

        public Vector3 offset;
        public Vector3 _initialPosition;
        public Quaternion _initialRotation;
        public float rotationSpeed = 20f;

        public GameObject lilPNG;
        public GameObject blocker;

        public float forwardForce = 2000f;
        public float sidewaysForce = 500f;

        void Awake()
        {
            camShook = gameObject.AddComponent<CamShook>();
            ui = gameObject.AddComponent<PNGPop>();
        }
        // Update is called once per frame
        void OnEnable()
        {
            if (camShook)
                Attach(camShook);
            if (ui)
                Attach(ui);

            _initialPosition = gameObject.transform.localPosition;
        }

        void OnDisable()
        {
            if (camShook)
                Detach(camShook);
            if (ui)
                Detach(ui);
        }
        void Update()
        {
            scoreText.text = player.position.z.ToString("0");
            if (player.position.z >= 300)
            {
                DrunkScore = true;
                NotifyObservers();
            }
            if (player.position.z >= 200)
            {
                pngScore = true;
                NotifyObservers();
            }
            if (player.position.z >= 500)
            {
                blockedScore = true;
                NotifyObservers();
            }
        }
        public void Drunk()
        {
            if (DrunkScore && !drunk)
            {
                Vector3 newPosition = player.position + player.forward * 10.7f;
                cam.transform.position = newPosition;
                cam.transform.LookAt(player.position);
            }
        }

        public void PNGTime()
        {
            lilPNG.SetActive(true);
        }

        public void blocked()
        {
            blocker.SetActive(true);
            lilPNG.SetActive(false);
        }

    }
}