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

    //public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {

        Vector3 spawnArea = Random.insideUnitSphere;
        spawnArea.y = 0;
        Instantiate(enemy, spawnArea * radius, Quaternion.identity);

        // Find a random index between zero and one less than the number of spawn points.
        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
