using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    private float speed = 10f;
    int damageAmount = 2;

    Rigidbody2D arrowrb2;


    void Start()
    {
        arrowrb2 = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (ArcherTowerController.instance.target==null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 direction = ArcherTowerController.instance.direction;
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
