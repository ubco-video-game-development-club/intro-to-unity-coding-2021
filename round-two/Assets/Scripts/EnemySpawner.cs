using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    public void OnEnemyDie()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().onDie.AddListener(OnEnemyDie);
    }

    private IEnumerator SpawnRoutine()
    {
        while(enabled)
        {
            yield return new WaitForSeconds(3.0f);
            SpawnEnemy();
        }
    }
}
