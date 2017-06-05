namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject enemy; // The enemy prefab to be spawned.

        [SerializeField]
        private float spawnTime = 3f;// How long between each spawn.            

        [SerializeField]
        private float radius = 10.0f;


        #region Public Methods
        public void Start()
        {
            Invoke("Spawn", spawnTime);
        }

        private void Spawn()
        {
            Vector3 spawnArea = Random.insideUnitSphere;
            spawnArea.y = 0;
            Instantiate(enemy, spawnArea * radius, Quaternion.identity);
            spawnTime *= 0.999f;
            Invoke("Spawn", spawnTime);
        }
        #endregion Public Methods
    }
}
