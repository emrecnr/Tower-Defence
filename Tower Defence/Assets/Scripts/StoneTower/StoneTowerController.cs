using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTowerController : MonoBehaviour
{
    public static StoneTowerController instance;
    public float range = 5f;  // ta� kulesinin menzili
    private float fireRate = 1f;  // ta� f�rlatma aral���

    public GameObject stonePrefab;  // ta� prefab

    private Transform target;

    public Transform firePoint; // ta��n ��k�� noktas�

    private float fireCountdown = 0f;  // ta� f�rlatma sayac�
    private void Start()
    {
        instance = this;
    }

    void Update()
    {

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);

        if (fireCountdown <= 0f && enemiesInRange.Length > 0 && enemiesInRange[0].CompareTag("Enemy"))
        {
            
            // Menzile giren ilk d��mana sald�r�r.
            target = enemiesInRange[0].transform;

            Shooting();


            // Ta� f�rlatma sayac� s�f�rlan�r.
            fireCountdown = 3f / fireRate;

        }
        
        // ta� f�rlatma sayac� azalt�l�r.
        fireCountdown -= Time.deltaTime;

    }
    void Shooting()
    {
        // Ok prefab'� olu�turma 
        GameObject stone = Instantiate(stonePrefab, firePoint.position, firePoint.rotation);
        Stone stoneScript = stone.GetComponent<Stone>();
        
        if (stone != null)
        {
            stoneScript.Seek(target);
        }
    }


    void OnDrawGizmosSelected() //Kule range g�sterimi
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
