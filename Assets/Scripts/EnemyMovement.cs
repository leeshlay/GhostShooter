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

        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            nav = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            nav.SetDestination(player.position);
        }

        /*void Update()
        {
            Debug.Log("in update");
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                    nav.SetDestination(hit.point);

            }
        }*/
    }
}
