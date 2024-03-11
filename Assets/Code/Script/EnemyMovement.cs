using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enemy di chuyen khi gia tri path tang len 1 

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed=2f;

    private int indexPath = 0;
    private Transform target;

    private void Start()
    {
        target = LevelManager.main.path[indexPath];
    }

    // Neu khoang cach giua 2 diem nho hon thi moi tang gia tri 
    private void Update()
    {
        if (Vector2.Distance(target.position,transform.position) <= 0.1f) indexPath++;

        if(indexPath == LevelManager.main.path.Length)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            target = LevelManager.main.path[indexPath];
        }

    }


    // Chuyen dong cua vat luc nao cung can co huong 
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}
