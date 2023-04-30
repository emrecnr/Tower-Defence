using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerBluePrint 
{

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    // Sat�� de�eri her zaman maliyetin yar�s�d�r.
    public int GetSellCost()
    {
        return cost / 2;
    }
}
