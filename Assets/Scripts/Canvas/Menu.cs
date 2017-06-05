using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [SerializeField]
    private GameVariables _gameVariables;

    public void PlayTheGame() {
        _gameVariables._GameOver = false;
        _gameVariables._Score = 0;
        SceneManager.LoadScene("GhostShooter");
    }

}
