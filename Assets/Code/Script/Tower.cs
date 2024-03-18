using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tower 
{
    public string name;
    //public int cost;
    public GameObject prefab;

    public Tower(string _name,GameObject _prefab)
    {
        name = _name;
        prefab = _prefab;
    }
}
