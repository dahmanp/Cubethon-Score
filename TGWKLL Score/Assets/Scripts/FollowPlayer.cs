using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class FollowPlayer : Observer
    {
        public Transform player;
        public bool isDrunk = false;
        public Vector3 offset;
        public Vector3 _initialPosition;
        public Quaternion _initialRotation;
        public float rotationSpeed = 20f;

        void OnEnable()
        {
            _initialPosition = gameObject.transform.localPosition;
        }

        void Update()
        {
            transform.position = player.position + offset;
            if (isDrunk)
            {
                Quaternion rotation = Quaternion.Euler(Time.time * rotationSpeed, 0, 0);
                transform.position = player.position + rotation * offset;
                transform.LookAt(player.position);
            }
            else
            {
                gameObject.transform.localRotation = _initialRotation;
            }
        }

        public override void Notify(Subject subject)
        {
            if (subject is Score score)
            {
                isDrunk = score.drunkScore;
            }
        }
    }
}
