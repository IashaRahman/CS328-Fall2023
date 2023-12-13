using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnincommons : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnInterval = 10f; // Time in seconds between each spawn

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        //spawn in distance
        Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
}
