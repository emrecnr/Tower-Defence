using UnityEngine;
using System.Collections;
using TMPro;


public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveIndex = 0;

    public TextMeshProUGUI waveText;

    private int waveNumber = 0;

    void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            Debug.Log("Level Won!!");
            this.enabled = false;
        }
        if (waveNumber>5)
        {
            return;
        }
        if (countdown<= 0f)
        {
            StartCoroutine(SpawnWave());  
            countdown = timeBetweenWaves;
            waveText.text = waveNumber.ToString()+"/"+5;
            return;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;
        waveNumber++;
       
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,Quaternion.identity);
        enemiesAlive++;
    }
}
