namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class BonusTimer : MonoBehaviour
    {

        private Text _BonusText;

        public void Start()
        {
            _BonusText = gameObject.GetComponent<Text>();
        }

        public void AddBonusTimerText(string _BonusName)
        {
            _BonusText.text = _BonusName;
            Invoke("Clear", 1.0f);
        }

        private void Clear()
        {
            _BonusText.text = "";
        }
    }
}
