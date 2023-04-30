using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTowerController : MonoBehaviour
{
    public static StoneTowerController instance;
    public float range = 5f;  // taþ kulesinin menzili
    private float fireRate = 1f;  // taþ fýrlatma aralýðý

    public GameObject stonePrefab;  // taþ prefab

    private Transform target;

    public Transform firePoint; // taþýn çýkýþ noktasý

    private float fireCountdown = 0f;  // taþ fýrlatma sayacý
    private void Start()
    {
        instance = this;
    }

    void Update()
    {

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);

        if (fireCountdown <= 0f && enemiesInRange.Length > 0 && enemiesInRange[0].CompareTag("Enemy"))
        {
            
            // Menzile giren ilk düþmana saldýrýr.
            target = enemiesInRange[0].transform;

            Shooting();


            // Taþ fýrlatma sayacý sýfýrlanýr.
            fireCountdown = 3f / fireRate;

        }
        
        // taþ fýrlatma sayacý azaltýlýr.
        fireCountdown -= Time.deltaTime;

    }
    void Shooting()
    {
        // Ok prefab'ý oluþturma 
        GameObject stone = Instantiate(stonePrefab, firePoint.position, firePoint.rotation);
        Stone stoneScript = stone.GetComponent<Stone>();
        
        if (stone != null)
        {
            stoneScript.Seek(target);
        }
    }


    void OnDrawGizmosSelected() //Kule range gösterimi
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
