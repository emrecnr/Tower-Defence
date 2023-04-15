using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Oluþturulacak düþmanýn prefab'ý
    public int numberOfEnemies; // Oluþturulacak düþman sayýsý
    public float spawnInterval; // Düþmanlarýn spawnlanma aralýðý (saniye cinsinden)
    public Transform spawnPoint; // Düþmanlarýn spawn noktasý

    private int enemiesSpawned = 0; // Þu ana kadar spawn edilen düþman sayýsý
    private bool spawningFinished = false; // Tüm düþmanlar spawn edildi mi?

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (!spawningFinished)
        {
            // numberOfEnemies kadar düþman spawn edilene kadar spawnInterval aralýklarla çalýþacak döngü
            if (enemiesSpawned < numberOfEnemies)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                enemiesSpawned++;
                yield return new WaitForSeconds(spawnInterval);
            }
            else
            {
                spawningFinished = true;
            }
        }
    }

}
