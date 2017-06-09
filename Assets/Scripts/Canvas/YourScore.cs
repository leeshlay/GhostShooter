namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


    public class YourScore : MonoBehaviour
    {

        private Text _Text;
        [SerializeField] private GameVariables _GameVariables;


        private void Awake()
        {
            _Text = GetComponent<Text>();
        }

        private void Update()
        {
            _Text.text = "Your Score: " + _GameVariables._Score;
        }
    }
}