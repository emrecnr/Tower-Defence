using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerController : MonoBehaviour
{
    public static ArcherTowerController instance;
    public float range = 5f;  // okçu kulesinin menzili
    private float fireRate = 1f;  // ok fýrlatma aralýðý

    public GameObject arrowPrefab;  // ok prefab

    private Transform target;

    private float fireCountdown = 0f;  // ok fýrlatma sayacý
    private void Start()
    {
        instance = this;
    }
    
    //void FindTarget()
    //{
    //    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    //    float shortestDistance = Mathf.Infinity;
    //    GameObject nearestEnemy = null;
    //    foreach (GameObject enemy in enemies) 
    //    {
    //        float disctanceToEnemy = Vector3.Distance(transform.position,enemy.transform.position);
    //        if (disctanceToEnemy<shortestDistance)
    //        {
    //            shortestDistance = disctanceToEnemy;
    //            nearestEnemy = enemy;
    //        }
    //    }
    //    if (nearestEnemy!=null&&shortestDistance<= range)
    //    {
    //        currentTarget = nearestEnemy.transform; 
    //    }
    //}

    void Update()
    {

        //if (currentTarget== null) 
        //{

        //    return;

        //}




        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, range);

        if (fireCountdown <= 0f && enemiesInRange.Length > 0 && enemiesInRange[0].CompareTag("Enemy"))
        {
            Shooting();
            // Menzile giren ilk düþmana saldýrýr.
            target = enemiesInRange[0].transform;

            // Ok prefab'ýný doðru yöne çevirmek için hedefe doðru yön belirleyin.
            Vector2 direction = target.position - transform.position;

             // Ok fýrlatma sayacý sýfýrlanýr.
            fireCountdown = 3f / fireRate;

        }
        //else { currentTarget = null; }

        // Ok fýrlatma sayacý azaltýlýr.
        fireCountdown -= Time.deltaTime;


    }
    void Shooting()
    {
        // Ok prefab'ý oluþturma ve hedefe hýzlandýrma
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        Arrow arrowScript = arrow.GetComponent<Arrow>();
        if (arrow != null)
        {
            arrowScript.Seek(target);
        }
    }
    
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
