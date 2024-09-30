using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class PNGPop : Observer
    {
        public bool isBlocked;
        public bool isPopped;
        private Score score;

        void Update()
        {
            if (isBlocked == true)
            {
                score.blocked();
            }
            if (isPopped == true)
            {
                score.PNGTime();
            }
        }

        public override void Notify(Subject subject)
        {
            if (!score)
            {
                score = subject.GetComponent<Score>();
            }
            if (score)
            {
                isPopped = score.pngScore;
                isBlocked = score.blockedScore;
            }
        }
    }
}
