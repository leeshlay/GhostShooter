namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class BestScore : MonoBehaviour
    {

        private Text _Text;
        [SerializeField] private GameVariables _GameVariables;


        private void Awake()
        {
            _Text = GetComponent<Text>();
        }

        private void Update()
        {
            _Text.text = "Best Score: " + _GameVariables._BestScore;
        }
    }
}
