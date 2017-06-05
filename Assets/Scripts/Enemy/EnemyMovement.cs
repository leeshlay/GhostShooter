namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;

    public class EnemyMovement : MonoBehaviour
    {

        private Transform player;
        private NavMeshAgent nav;
        [SerializeField] private GameVariables _GameVariables;

        #region Public Methods
        void Start()
        {
            if (!_GameVariables._GameOver)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                nav = GetComponent<NavMeshAgent>();
            }
                
        }

        void Update()
        {
            if (!_GameVariables._GameOver)
            {
                nav.SetDestination(player.position);
            }   
        }

        #endregion Public Methods

    }
}
