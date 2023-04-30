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

    // Satýþ deðeri her zaman maliyetin yarýsýdýr.
    public int GetSellCost()
    {
        return cost / 2;
    }
}
