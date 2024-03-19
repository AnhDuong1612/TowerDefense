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
    [SerializeField] private GameObject[] towerPrefabs;

    [Header("Attributes")]
    [SerializeField] public GameObject selectUI;
    [SerializeField] private Button[] towerButtons;
    public bool state;

    private void Start()
    {
        for (int i = 0; i < towerButtons.Length; i++)
        {
            int index = i; // Capturing the loop variable
            towerButtons[i].onClick.AddListener(() => AddTower(index));
        }
    }

    public void AddTower(int index)
    {
        if (index >= 0 && index < towerPrefabs.Length)
        {
           

            GameObject towerToBuild = towerPrefabs[index];
            GameObject newTower = Instantiate(towerToBuild, transform.position, Quaternion.identity);

            ToggleUI();
        }
        else
        {
            Debug.LogWarning("Tower index out of bounds.");
        }
    }

    public void ToggleUI()
    {
        state = !state;
        selectUI.SetActive(state);
    }

    public void OnMouseDown()
    {
        ToggleUI();
    }
}
