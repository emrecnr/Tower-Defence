using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerController : MonoBehaviour
{
    public static ArcherTowerController instance;


    public float range = 5f;  // ok�u kulesinin menzili
    public float fireRate = 1f;  // ok f�rlatma aral���

    public GameObject arrowPrefab;  // ok prefab

    

    public Transform target;

    public Vector2 direction;

    private float fireCountdown = 0f;  // ok f�rlatma sayac�
    void Start()
    {
        instance = this;
    }


    void Update()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);

        if (fireCountdown <= 0f && enemiesInRange.Length > 0)
        {
            // Menzile giren ilk d��mana sald�r�r.
            target = enemiesInRange[0].transform;

            // Ok prefab'�n� do�ru y�ne �evirmek i�in hedefe do�ru y�n belirleyin.
            direction = target.position - transform.position;

             // Ok prefab'� olu�turma ve hedefe h�zland�rma
            GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            //arrow.GetComponent<Rigidbody2D>().velocity = direction.normalized * 10f;

            // Ok f�rlatma sayac� s�f�rlan�r.
            fireCountdown = 1f / fireRate;
        }
        
        
        // Ok f�rlatma sayac� azalt�l�r.
        fireCountdown -= Time.deltaTime;
           
    }
    
    
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
