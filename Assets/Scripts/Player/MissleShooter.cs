using System.Collections;
using System.Collections.Generic;
using TGK.Project;
using UnityEngine;

public class MissleShooter : MonoBehaviour {

    [SerializeField]
    private GameObject misslePrefab;

    [SerializeField]
    private GameObject instantiatePlace;

    [SerializeField]
    private float missleSpeed = 5.0f;

    public void Shoot(Vector3 shootDirection) {

        // Create new missle at instantiatePlace
        var missle = Instantiate(
                misslePrefab,
                instantiatePlace.transform.position,
                Quaternion.FromToRotation(instantiatePlace.transform.position, shootDirection)
            );

        // Add velocity to the missle
        Rigidbody missleRigidbody = missle.GetComponent<Rigidbody>();
        missleRigidbody.velocity = shootDirection.normalized * missleSpeed;

    }


}
