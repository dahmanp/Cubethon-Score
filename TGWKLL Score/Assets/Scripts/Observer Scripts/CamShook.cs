using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class CamShook : Observer
    {
        private bool isDrunk = false;
        private Score score;

        void Update()
        {
            if (isDrunk == true)
            {
                score.Drunk();
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
                isDrunk = score.DrunkScore;
            }
        }
    }
}
