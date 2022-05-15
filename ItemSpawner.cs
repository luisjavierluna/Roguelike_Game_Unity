using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] int spawnRadius = 6;

    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int powerUpTime = 5;

    [SerializeField] GameObject checkPointPrefab;
    [SerializeField] int checkPointTime = 8;

    private void Start()
    {
        StartCoroutine(SpawnCheckPointRoutine());
        StartCoroutine(SpawnPowerURoutine());
    }

    IEnumerator SpawnCheckPointRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkPointTime);
            Vector2 randomSpawnZone = Random.insideUnitCircle * spawnRadius;
            Instantiate(checkPointPrefab, randomSpawnZone, Quaternion.identity);
        }
    }

    IEnumerator SpawnPowerURoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpTime);
            Vector2 randomSpawnZone = Random.insideUnitCircle * spawnRadius;
            int randomPowerUp = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[randomPowerUp],
                randomSpawnZone, Quaternion.identity);
        }
    }
}