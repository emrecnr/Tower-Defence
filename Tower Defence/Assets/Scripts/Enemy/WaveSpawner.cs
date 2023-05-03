using UnityEngine;
using System.Collections;
using TMPro;


public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;
    public Manager manager;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveIndex = 0;

    public TextMeshProUGUI waveText;

    private int waveNumber = 1;

    void Start()
    {
        enemiesAlive = 0;
        waveText.text = 0 + "/" + 4;
    }

    void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }
        if (waveIndex == waves.Length)
        {
            manager.WinLevel();
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
            waveText.text = waveNumber.ToString()+"/"+4;
            return;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        HealthSystem.rounds++;
        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(3f/wave.rate);
        }
        waveIndex++;
        waveNumber++;
       
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy,spawnPoint.position,Quaternion.identity);
        
    }
    //https://www.canva.com/design/DAFhy3ihtgo/n8fmv8OfYyBRvmP0PQktcQ/edit
}
