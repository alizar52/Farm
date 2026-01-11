using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;

    private float startDelay = 2f;
    private float minSpawnInterval = 1f;
    private float maxSpawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnAnimalsWithRandomInterval());
    }

    IEnumerator SpawnAnimalsWithRandomInterval()
    {
        // Ждем начальную задержку
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // Выбираем случайный интервал
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Спавним животное
            SpawnRandomAnimal();

            // Ждем перед следующим спавном
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
