namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;

    public class EnemyMovement : MonoBehaviour
    {

        private Transform _Player;
        private NavMeshAgent _Nav;
        [SerializeField] private GameVariables _GameVariables;

        #region Public Methods
        void Start()
        {
            if (!_GameVariables._GameOver)
            {
                _Player = GameObject.FindGameObjectWithTag("Player").transform;
                _Nav = GetComponent<NavMeshAgent>();
            }
                
        }

        void Update()
        {
            if (!_GameVariables._GameOver)
            {
                _Nav.SetDestination(_Player.position);
            }   
        }

        #endregion Public Methods

    }
}
