namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class Menu : MonoBehaviour
    {

        [SerializeField]
        private GameVariables _GameVariables;

        public void OnLevelWasLoaded(int level)
        {

            if (_GameVariables._BestScore < _GameVariables._Score)
            {
                _GameVariables._BestScore = _GameVariables._Score;
            }
        }

        public void PlayTheGame()
        {
            _GameVariables._Score = 0;
            _GameVariables._GameOver = false;
            SceneManager.LoadScene("GhostShooter");
        }
    }
}
