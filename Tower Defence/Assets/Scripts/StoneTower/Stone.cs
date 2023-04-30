using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject explosionEffect;//patlama efekti

    private float speed = 3f;

    public float explosionRadius = 5f; // patlama yarýçapý
    
    public int damage = 50; // vereceði hasar

    
    Rigidbody2D rb;
    
    private float launchHeight = 15;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    private Transform target;

    public void Seek(Transform targets)
    {
        target = targets;
        
    }
    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        


        GoToTarget();
    }
   

    void HitTarget() // taþýn düþtüðü yerde düþmana hasar vermesi
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 1f);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
    void GoToTarget() // taþýn düþmana doðru gitmesi
    {
        
        Vector2 direction = target.position - transform.position;
        transform.right = direction;
        rb.velocity = transform.right * speed;
        
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
