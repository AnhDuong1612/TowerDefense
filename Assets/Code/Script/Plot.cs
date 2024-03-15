using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    // mau sac sau khi nhap vao
    [SerializeField] private Color hoverColor;
    [SerializeField] private int countTurret = 0;

    private GameObject tower;
    // mau sac khi chua nhap vao 
    private Color startColor;
    //public Turrest turret;


    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        //if (UIManager.main.IsHoveringUI()) return;
        // Neu UI dang duoc hien len thi dung cac ham ben duoi lai con khong thi vx tiep tuc chay . Vi du UI khong hien le
        // Để chương trình chạy được thì gía trị lúc tắt phải trở về false nếu không sẽ không kích hoạt được sự kiện 

        // Neu nut an UI = true thi doan code phia duoi dung
        // Neu nut an UI = false tuc la chua hien thi giao dien thi co kha nang la no da sinh ra thap hoac la kha nang hien ra ui 


        //if (tower != null)
        //{
        //    turret.OpenUpgradeUI();
        //    return;
        //}

        // khong co thap thi tao thap // co thap thi mo ui chua giao dien nut nang ca // neu mo giao dien nut nang cap thi can an vao nut day neu nut an da duoc an thi dung 
        // tai sao phai kiem tra mo dong ui 

        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
        IncreaseTurrets();
        //turret = tower.GetComponent<Turrest>();
    }

    public void IncreaseTurrets()
    {
        countTurret++;
    }
}
// neu ma ishoveringui duoc kich hoat thi no dung lai . ishoveringui se tra ve trang thai hien dang cai dat 