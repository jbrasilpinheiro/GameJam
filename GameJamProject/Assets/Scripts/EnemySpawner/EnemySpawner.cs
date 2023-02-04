using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnCooldown = 2.0f;
    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnCooldown)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0.0f;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}

