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
        private bool isOver = false;

        #region Public Methods
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            nav = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (!isOver)
            {
                nav.SetDestination(player.position);
            }   
        }

        #endregion Public Methods

        private void GameOver(Messages.GameOver message)
        {
            isOver = true;
        }

    }
}
