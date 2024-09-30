using UnityEngine;

namespace Chapter.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void Notify(Subject subject);
    }
}

//if you hit the side bars, the cam will rotate in circles for 3 seconds after respawn
//if you win, you get sent to the video
//BLANK