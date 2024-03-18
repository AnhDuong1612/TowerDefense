using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private int countTurret = 0;
    [SerializeField] private GameObject bowTower;

    [Header("Attributes")]
    [SerializeField] public GameObject selectUI;
    [SerializeField] private Button bowTowerBtn;
    [SerializeField] private Button soliderTowerBtn;
    [SerializeField] private Button magicTowerBtn;
    [SerializeField] private Button lighteningTowerBtn;

    public bool state;

    private void Start() {
        bowTowerBtn.onClick.AddListener(AddBowTower);
        soliderTowerBtn.onClick.AddListener(AddSoliderTower);
        magicTowerBtn.onClick.AddListener(AddMagicTower);
        lighteningTowerBtn.onClick.AddListener(AddLighteningTower);
    }

    public void AddBowTower() {
        Tower bowTowerToBuild = BuildManager.main.GetSelectedTower();
        bowTower = Instantiate(bowTowerToBuild.prefab, transform.position, Quaternion.identity);

        ToggleUI();
    }

    private void AddLighteningTower() {
        Tower bowTowerToBuild = BuildManager.main.GetSelectedTower();
        bowTower = Instantiate(bowTowerToBuild.prefab, transform.position, Quaternion.identity);

        ToggleUI();
    }

    private void AddMagicTower() {
        Tower bowTowerToBuild = BuildManager.main.GetSelectedTower();
        bowTower = Instantiate(bowTowerToBuild.prefab, transform.position, Quaternion.identity);

        ToggleUI();
    }

    private void AddSoliderTower() {
        Tower bowTowerToBuild = BuildManager.main.GetSelectedTower();
        bowTower = Instantiate(bowTowerToBuild.prefab, transform.position, Quaternion.identity);

        ToggleUI();
    }

    //private void OnMouseDown()
    //{
    //    //if (UIManager.main.IsHoveringUI()) return;

    //    //if (tower != null)
    //    //{
    //    //    turret.OpenUpgradeUI();
    //    //    return;
    //    //}

    //    GameObject towerToBuild = BuildManager.main.GetSelectedTower();
    //    tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    //    IncreaseTurrets();
    //    //turret = tower.GetComponent<Turrest>();
    //}

    //public void IncreaseTurrets()
    //{
    //    countTurret++;
    //}

    public void ToggleUI() {
        state = !state;
        selectUI.SetActive(state);
    }

    public void OnMouseDown() {
        ToggleUI();
    }
}
