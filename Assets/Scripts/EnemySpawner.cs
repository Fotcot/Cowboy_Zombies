using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;
    

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0) return;

        GameObject enemy = EnemyPool.Instance.GetEnemy();
        if (enemy == null) return; // No spawnea si ya hay muchos enemigos

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        enemy.transform.position = spawnPoint.position;
        enemy.transform.rotation = Quaternion.identity;
    }

}