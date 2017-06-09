namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using TGK.Project;
    using UnityEngine;

    public class MissleShooter : MonoBehaviour
    {

        [SerializeField]
        private GameObject _MisslePrefab;

        [SerializeField]
        private GameObject _InstantiatePlace;

        [SerializeField]
        private float _MissleSpeed = 5.0f;

        [SerializeField]
        private AudioSource shotAudioSource;

        public void Shoot(Vector3 shootDirection)
        {

            Vector3 spawnPosition = _InstantiatePlace.transform.position;
            spawnPosition.y = 1.0f;

            // Create new missle at instantiatePlace
            var missle = Instantiate(
                    _MisslePrefab,
                    spawnPosition,
                    Quaternion.FromToRotation(_InstantiatePlace.transform.position, shootDirection)
                );

            // Add velocity to the missle
            Rigidbody missleRigidbody = missle.GetComponent<Rigidbody>();
            missleRigidbody.velocity = shootDirection.normalized * _MissleSpeed;

            shotAudioSource.Play();
        }
    }
}
