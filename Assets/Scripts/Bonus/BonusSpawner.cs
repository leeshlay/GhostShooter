using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject bonus; // The bonus prefab to be spawned.

    [SerializeField]
    private float spawnTime = 5f; // How long between each spawn.            

    [SerializeField]
    private float radius = 10.0f;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn()
    {
        Vector3 spawnArea = Random.insideUnitSphere;
        spawnArea *= radius;
        spawnArea.y = 1;
        Instantiate(bonus, spawnArea, Quaternion.identity);
    }
}
