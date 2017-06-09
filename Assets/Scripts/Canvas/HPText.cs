namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class HPText : MonoBehaviour
    {

        private Health _Health;

        private Text _Text;

        private void Awake()
        {
            _Text = GetComponent<Text>();
            _Health = FindObjectOfType(typeof(Health)) as Health;
        }

        private void Update()
        {
            var hp = _Health.getHealth() <= 0 ? 0.0 : _Health.getHealth();
            _Text.text = "HP " + hp.ToString("F2");
        }

    }
}
