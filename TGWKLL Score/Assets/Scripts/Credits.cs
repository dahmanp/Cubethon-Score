using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public class Credits : MonoBehaviour
    {
        public void Quit()
        {
            Application.OpenURL("https://www.youtube.com/watch?v=mx86-rTclzA");
        }

        public void OpenWebLink()
        {
            Application.OpenURL("https://www.youtube.com/watch?v=mx86-rTclzA");
        }
    }
}
