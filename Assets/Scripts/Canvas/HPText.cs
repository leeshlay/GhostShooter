namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class HPText : MonoBehaviour
    {

        private Health health;

        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
            health = FindObjectOfType(typeof(Health)) as Health;
        }

        private void Update()
        {
            text.text = "HP: " + health.getHealth(); //"HP  " + player.getHP();
        }

    }
}
