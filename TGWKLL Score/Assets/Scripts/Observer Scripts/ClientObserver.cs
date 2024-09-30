using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class ClientObserver : MonoBehaviour
    {
        private PlayerMovement movement;
        void Start()
        {
            movement = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));
        }
    }
}