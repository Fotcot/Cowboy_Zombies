using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    public GameObject enemyPrefab;
    public int poolSize = 45;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    public int maxActiveEnemies = 20; // Límite de enemigos activos
    private int activeEnemies = 0; // Contador de enemigos activos

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        if (activeEnemies >= maxActiveEnemies) return null; // No spawnea más

        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            activeEnemies++;
            return enemy;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab);
            activeEnemies++;
            return enemy;
        }
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
        activeEnemies--; // Reducimos el contador al eliminar un enemigo
    }

}
