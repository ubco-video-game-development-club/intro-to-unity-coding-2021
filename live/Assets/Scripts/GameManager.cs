using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public float spawnRange;
    public float spawnHeight;
    public float spawnDelay;
    public int numEnemies;

    void Start()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRange, spawnRange), spawnHeight);
        Enemy enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.deathEvent.AddListener(DelayedSpawn);
    }

    private void DelayedSpawn()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy();
    }
}
