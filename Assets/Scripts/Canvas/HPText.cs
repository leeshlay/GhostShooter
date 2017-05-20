using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour {

    private Player player;

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    private void Update()
    {
        text.text = "HP  " + player.getHP();
    }

}
