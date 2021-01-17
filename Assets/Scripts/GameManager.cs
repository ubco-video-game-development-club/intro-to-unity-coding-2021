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

    private YieldInstruction spawnDelayInstruction;

    void Start()
    {
        spawnDelayInstruction = new WaitForSeconds(spawnDelay);

        for (int i = 0; i < numEnemies; i++)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        yield return spawnDelayInstruction;
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRange, spawnRange), spawnHeight);
        Enemy enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.deathEvent.AddListener(OnEnemyDie);
    }

    private void OnEnemyDie()
    {
        StartCoroutine(SpawnEnemy());
    }
}
