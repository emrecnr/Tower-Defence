using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Arrow : MonoBehaviour
{
    private float speed = 10f;
    int damageAmount = 2;
    private Transform targetEnemy;
    Rigidbody2D arrowrb2;


    void Start()
    {
        arrowrb2 = GetComponent<Rigidbody2D>();
    }

    public void Seek(Transform target)
    {
        targetEnemy = target;
    }
    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = targetEnemy.position-transform.position;
        transform.right = direction;
        arrowrb2.velocity = direction.normalized * speed;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
