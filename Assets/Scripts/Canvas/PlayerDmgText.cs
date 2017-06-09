namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerDmgText : MonoBehaviour
    {

        private Player _Player;

        private Text _Text;

        private void Awake()
        {
            _Text = GetComponent<Text>();
            _Player = FindObjectOfType(typeof(Player)) as Player;
        }

        private void Update()
        {
            _Text.text = "DMG  " + _Player.getDamage();
        }
    }
}
