using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    private GameVariables _gameVariables;

    public void OnLevelWasLoaded(int level)
    {
        
        if (_gameVariables._BestScore < _gameVariables._Score)
        {
            _gameVariables._BestScore = _gameVariables._Score;
        }
       
    }

    public void PlayTheGame() {
        _gameVariables._Score = 0;
        _gameVariables._GameOver = false;
        SceneManager.LoadScene("GhostShooter");
    }

}
