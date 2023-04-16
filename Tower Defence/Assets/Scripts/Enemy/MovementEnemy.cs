using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    // D��man�n hedefine do�ru hareket etti�i h�z
     float speed = 2f;

    // D��man�n mevcut hedef noktas�
    private int targetIndex = 0;

    // Ba�lang��ta d��man� hareketsiz yapar
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

    // D��man�n hedef noktas�na do�ru hareket etmesini sa�layan fonksiyon
    void MoveToTarget()
    {
        // D��man�n hareket edece�i hedef noktas�n� belirle
        Vector3 targetPosition = pathFinding.pathPoints[targetIndex].position;

        // D��man�n hedefe do�ru hareket etmesini sa�la
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // E�er d��man hedef noktaya ula�t�ysa, bir sonraki hedef noktaya ge�
        if (transform.position == targetPosition)
        {
            targetIndex++;

            // E�er t�m hedef noktalar� gezdiyse, d��man� yok et
            if (targetIndex >= pathFinding.pathPoints.Count)
            {
                HealthSystem.instance.TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
    }

    // D��man�n hareketini ba�latan fonksiyon
    public void StartMoving()
    {
        isMoving = true;
    }

    // D��man�n hedef noktalar�n� atan fonksiyon
    public void SetPathPoints(List<Transform> points)
    {
        pathFinding.pathPoints = points;
    }
}
