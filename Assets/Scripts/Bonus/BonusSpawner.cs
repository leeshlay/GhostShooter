namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BonusSpawner : MonoBehaviour
    {

        [SerializeField]
        private GameObject _Bonus;

        [SerializeField]
        private float _SpawnTime = 5f;            

        [SerializeField]
        private float _Radius = 10.0f;

        void Start()
        {
            InvokeRepeating("Spawn", _SpawnTime, _SpawnTime);
        }

        private void Spawn()
        {
            Vector3 spawnArea = Random.insideUnitSphere;
            spawnArea *= _Radius;
            spawnArea.y = 1;
            Instantiate(_Bonus, spawnArea, Quaternion.identity);
        }
    }
}
