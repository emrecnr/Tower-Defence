using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    // Düþmanýn hedefine doðru hareket ettiði hýz
     float speed = 2f;

    // Düþmanýn mevcut hedef noktasý
    private int targetIndex = 0;

    // Baþlangýçta düþmaný hareketsiz yapar
    private bool isMoving = true;

    private PathFinding pathFinding;

    int damageAmount = 1;
    private void Update()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
    }

    private void Start()
    {
        pathFinding = FindObjectOfType<PathFinding>();
    }

    // Düþmanýn hedef noktasýna doðru hareket etmesini saðlayan fonksiyon
    void MoveToTarget()
    {
        // Düþmanýn hareket edeceði hedef noktasýný belirle
        Vector3 targetPosition = pathFinding.pathPoints[targetIndex].position;

        // Düþmanýn hedefe doðru hareket etmesini saðla
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Eðer düþman hedef noktaya ulaþtýysa, bir sonraki hedef noktaya geç
        if (transform.position == targetPosition)
        {
            targetIndex++;

            // Eðer tüm hedef noktalarý gezdiyse, düþmaný yok et
            if (targetIndex >= pathFinding.pathPoints.Count)
            {
                HealthSystem.instance.TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
    }

    // Düþmanýn hareketini baþlatan fonksiyon
    public void StartMoving()
    {
        isMoving = true;
    }

    // Düþmanýn hedef noktalarýný atan fonksiyon
    public void SetPathPoints(List<Transform> points)
    {
        pathFinding.pathPoints = points;
    }
}
