using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerController : MonoBehaviour
{
    public static ArcherTowerController instance;


    public float range = 5f;  // okçu kulesinin menzili
    public float fireRate = 1f;  // ok fýrlatma aralýðý

    public GameObject arrowPrefab;  // ok prefab

    

    public Transform target;

    public Vector2 direction;

    private float fireCountdown = 0f;  // ok fýrlatma sayacý
    void Start()
    {
        instance = this;
    }


    void Update()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);

        if (fireCountdown <= 0f && enemiesInRange.Length > 0)
        {
            // Menzile giren ilk düþmana saldýrýr.
            target = enemiesInRange[0].transform;

            // Ok prefab'ýný doðru yöne çevirmek için hedefe doðru yön belirleyin.
            direction = target.position - transform.position;

             // Ok prefab'ý oluþturma ve hedefe hýzlandýrma
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            //arrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10f;

            // Ok fýrlatma sayacý sýfýrlanýr.
            fireCountdown = 1f / fireRate;
        }
        
        
        // Ok fýrlatma sayacý azaltýlýr.
        fireCountdown -= Time.deltaTime;
           
    }
    
    
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
