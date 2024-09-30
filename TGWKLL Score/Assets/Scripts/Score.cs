using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Chapter.Observer
{
    public class Score : Subject
    {
        public Transform player;
        public Text scoreText;
        private FollowPlayer cam;
        public bool oppositeScore;
        public bool drunkScore;

        void Awake()
        {
            cam = gameObject.AddComponent<FollowPlayer>();
        }
        // Update is called once per frame
        void OnEnable()
        {
            if (cam)
                Attach(cam);
        }

        void OnDisable()
        {
            if (cam)
                Detach(cam);
        }

        void Update()
        {
            scoreText.text = player.position.z.ToString("0");
            if (player.position.z >= 500 && !drunkScore)
            {
                drunkScore = true;
                NotifyObservers();
            }
            else if (player.position.z >= 200 && !oppositeScore)
            {
                oppositeScore = true;
                NotifyObservers();
            }
        }
    }
}
