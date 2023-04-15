using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Olu�turulacak d��man�n prefab'�
    public int numberOfEnemies; // Olu�turulacak d��man say�s�
    public float spawnInterval; // D��manlar�n spawnlanma aral��� (saniye cinsinden)
    public Transform spawnPoint; // D��manlar�n spawn noktas�

    private int enemiesSpawned = 0; // �u ana kadar spawn edilen d��man say�s�
    private bool spawningFinished = false; // T�m d��manlar spawn edildi mi?

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (!spawningFinished)
        {
            // numberOfEnemies kadar d��man spawn edilene kadar spawnInterval aral�klarla �al��acak d�ng�
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
