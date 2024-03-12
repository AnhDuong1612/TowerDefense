using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// toc  do xoay , pham vi ban : attribute , vi tri cua thap : reference
// cho quay ve huong enemy , neu tim thay enemy thi ban vao enemy 


// Sai huong

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;


    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float rotationSpeed = 5f;



    private Transform target;

    // Neu kong tim duoc doi tuong tra ve null , tim duoc doi tuong thi xoay theo doi tuong
    private void Update()
    {
        if(target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardTarget();

        if(!CheckIsInRange())
        {
            target = null;
        }

    }

    private bool CheckIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }


    // De tim doi tuong thi tao vung quet phat hien va cham voi doi tuong : raycasthit2D
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if(hits.Length>0)
        {
            target = hits[0].transform;
        }
    }

    // De tim diem xoay phai tinh goc roi xoay theo huong goc phai dung quaternion.euler de xoay theo goc 
    private void RotateTowardTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x)*Mathf.Rad2Deg + 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = targetRotation; 
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position,transform.forward,targetingRange);
    }
}
