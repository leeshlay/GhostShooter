namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class HPText : MonoBehaviour
    {

        private Health _health;

        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _health = FindObjectOfType(typeof(Health)) as Health;
        }

        private void Update()
        {
            var hp = _health.getHealth() <= 0 ? 0.0 : _health.getHealth();
            _text.text = "HP " + hp.ToString("F2");
        }

    }
}
