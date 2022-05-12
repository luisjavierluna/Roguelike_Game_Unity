using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [Range(1, 10)][SerializeField] float spawnRate = 1;


    private void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / spawnRate);
            float randomEnemy = Random.Range(0.0f, 1.0f);
            if (randomEnemy > 0.1f)
            {
                Instantiate(enemyPrefabs[0]);
            }
            else
            {
                Instantiate(enemyPrefabs[1]);
            }
        }
    }
}
