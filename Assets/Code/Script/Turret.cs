using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
// toc  do xoay , pham vi ban : attribute , vi tri cua thap : reference
// cho quay ve huong enemy , neu tim thay enemy thi ban vao enemy 


// Sai huong


public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    //2
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject selectUI;


    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;
    //[SerializeField] private float rotationSpeed = 5f;
    //2
    [SerializeField] private float bps = 1f;


    private Transform target;
    private float timeUntilFire;
    private bool stateUI; // Sử dụng biến này để theo dõi trạng thái của UI

    private void Start()
    {
        CloseSelectUI();
    }

    private void Update()
    {
        if(target == null)
        {
            FindTarget();
            return;
        }
        //RotateTowardTarget();

        if(!CheckIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if(timeUntilFire >= 1f/bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }

    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private bool CheckIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if(hits.Length>0)
        {
            target = hits[0].transform;
        }
    }

    public void Select()
    {
        selectUI.SetActive(false);
        stateUI = false; ;
    }

    public void OpenSelectUI()
    {
        selectUI.SetActive(true);
        stateUI = true; 
    }

    public void CloseSelectUI()
    {
        selectUI.SetActive(false);
        stateUI = false;
    }

    public void ToggleSelectUI()
    {
        if (stateUI) CloseSelectUI();
        else OpenSelectUI();
    }

    public void OnMouseDown()
    {
        ToggleSelectUI();
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position,transform.forward,targetingRange);
    }
}
