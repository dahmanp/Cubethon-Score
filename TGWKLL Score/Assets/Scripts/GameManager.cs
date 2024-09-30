using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapter.Observer
{
    public class GameManager : Observer
    {
        bool gameHasEnded = false;
        public float restartDelay = 1f;
        public GameObject completeLevelUI;
        private PlayerMovement movement;
        public bool Opposite;

        public void EndGame()
        {
            if (gameHasEnded == false)
            {
                gameHasEnded = true;
                Invoke("Restart", restartDelay);
            }
        }

        void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void CompleteLevel()
        {
            completeLevelUI.SetActive(true);
        }

        public override void Notify(Subject subject)
        {
            if (subject is PlayerMovement playerMovement)
            {
                movement = playerMovement;
                Opposite = movement.Opposite;
            }
        }
    }
}
