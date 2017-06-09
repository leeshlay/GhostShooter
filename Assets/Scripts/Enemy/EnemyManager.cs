namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _Enemy;

        [SerializeField]
        private float _SpawnTime = 3f;           

        [SerializeField]
        private float _Radius = 10.0f;


        #region Public Methods
        public void Start()
        {
            Invoke("Spawn", _SpawnTime);
        }

        private void Spawn()
        {
            Vector3 spawnArea = Random.insideUnitSphere;
            spawnArea.y = 0;
            Instantiate(_Enemy, spawnArea * _Radius, Quaternion.identity);
            _SpawnTime *= 0.999f;
            Invoke("Spawn", _SpawnTime);
        }
        #endregion Public Methods
    }
}
