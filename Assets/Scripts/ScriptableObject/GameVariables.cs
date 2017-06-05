using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameVariables", menuName = "Game/Variables", order = 1)]
public class GameVariables : ScriptableObject {

    public int _Score = 0;
    public bool _GameOver = false;

}
