using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject temp; //Temp
    public float spawnRate = 5f;

    private float nextSpawnTime;

    void Start()
    {
    // Initialize next spawn time
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        
        if (Time.time >= nextSpawnTime && commonEnemyPrefab != null)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(commonEnemyPrefab, transform.position, Quaternion.identity);
        Debug.Log("Spawned an enemy.");
    }
}
